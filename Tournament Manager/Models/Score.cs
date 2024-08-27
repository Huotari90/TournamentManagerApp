public class Score
{
	public int Id { get; set; }
	public string UserId { get; set; }
	public IdentityUser User { get; set; }
	public int Value { get; set; }
	public DateTime DateRecorded { get; set; }
}