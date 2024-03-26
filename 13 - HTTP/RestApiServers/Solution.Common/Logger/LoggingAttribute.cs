using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code.SyntaxBuilders;

[assembly: AspectOrder(typeof(LoggingAttribute), typeof(DependencyAttribute))]
namespace Solution.Common.Logger;

public class LoggingAttribute : OverrideMethodAspect
{
    [IntroduceDependency]
    protected readonly IHttpContextAccessor httpContextAccessor;

    public override dynamic OverrideMethod()
    {
        try
        {
            var user = (this.httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity).Claims.FirstOrDefault(x => x.Type == "uid");
            var loggedInUserIdentity = !string.IsNullOrEmpty(user?.Value) ?
                                       string.Format("=> by user: {0}", user.Value) :
                                       string.Empty;

            var message = BuildInterpolatedString();
            message.AddExpression(loggedInUserIdentity);
            var output = message.ToValue() as string;

            if (!string.IsNullOrWhiteSpace(output))
                Log.Logger.Information(output);

            var result = meta.Proceed();
            return result;
        }
        catch (Exception e)
        {
            var failureMessage = new InterpolatedStringBuilder();
            failureMessage.AddText(meta.Target.Method.Name);
            failureMessage.AddText(" failed: ");
            failureMessage.AddExpression(e.Message);

            var output = failureMessage.ToValue() as string;
            if (!string.IsNullOrWhiteSpace(output))
                Log.Logger.Information(output);

            throw;
        }
    }

    protected InterpolatedStringBuilder BuildInterpolatedString()
    {
        var i = meta.CompileTime(0);

        var stringBuilder = new InterpolatedStringBuilder();
        stringBuilder.AddText(string.Format("{0}.{1}", meta.Target.Type.Name, meta.Target.Method.Name));
        stringBuilder.AddText("(");

        foreach (var prop in meta.Target.Parameters)
        {
            var comma = i > 0 ? ", " : "";

            if (i > 0)
                stringBuilder.AddText(", ");

            var builder = new ExpressionBuilder();
            builder.AppendVerbatim("System.Text.Json.JsonSerializer.Serialize(");
            builder.AppendExpression(prop.CastTo<object>());
            builder.AppendVerbatim(")");

            stringBuilder.AddText(string.Format("{0} : ", prop.Name));
            stringBuilder.AddExpression(builder.ToExpression());

            i++;
        }

        stringBuilder.AddText(")");

        return stringBuilder;
    }
}
