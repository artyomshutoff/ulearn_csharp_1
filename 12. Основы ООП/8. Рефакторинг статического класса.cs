public class SuperBeautyImageFilter
{
    public string ImageName;
    public double GaussianParameter;
    public void Run()
    {
        Console.WriteLine(
          "Processing {0} with parameter {1}",
          this.ImageName,
          this.GaussianParameter.ToString(CultureInfo.InvariantCulture));
    }
}