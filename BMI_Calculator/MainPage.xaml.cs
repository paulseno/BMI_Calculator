namespace BMI_Calculator;

public partial class MainPage : ContentPage
{
    public enum Category
    {
        Underweight,
        Healthy,
        Overweight,
        Obese
    }

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnButtonClick(object? sender, EventArgs e)
    {
        if (double.TryParse(HeightEntry.Text, out double height) &&
            double.TryParse(WeightEntry.Text, out double weight))
        {
            double bmi = (weight / (height * height)) * 10000;

            Category category;

            if (bmi < 18.5)
                category = Category.Underweight;
            else if (bmi <= 24.9)
                category = Category.Healthy;
            else if (bmi <= 29.9)
                category = Category.Overweight;
            else
                category = Category.Obese;

            ResultLabel.Text = $"{bmi:F2}\n{category}";
            SemanticScreenReader.Announce(ResultLabel.Text);
        }
        else
        {
            ResultLabel.Text = "Please enter valid numbers.";
        }
    }
}