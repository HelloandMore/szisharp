public class YTVideo
{
	public int Length { get; set; }

	public string Author { get; set; }

	public string Title { get; set; }

	public int UploadDate { get; set; }

	public string TopicBriefly { get; set; }

	public string IsItMainstream { get; set; }

	public override string ToString()
	{
		if (IsItMainstream == True)
			return $"This YouTube video called '{this.Title}' was uploaded by '{this.Author}' on '{this.UploadDate}'\nThe video is about {this.TopicBriefly}, and the video is currently mainstream trending across YouTube.";
		else
			return $"This YouTube video called '{this.Title}' was uploaded by '{this.Author}' on '{this.UploadDate}'\nThe video is about {this.TopicBriefly}, and the video is currently not mainstream trending across YouTube.";
	}

}
