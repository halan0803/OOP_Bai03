/********************************
Mã sinh viên: 202418931
Họ tên: Trần Thị Hà Lan
********************************/
using System;

// SoftwareEngineer kế thừa từ Employee
public class SoftwareEngineer : Employee
{
    // Ngôn ngữ lập trình chính
    private string primaryLanguage;

    // Phụ cấp kỹ thuật
    private double technicalAllowance;

    // Constructor thứ nhất
    public SoftwareEngineer(
        string id,
        string fullName,
        string primaryLanguage)
        : base(id, fullName)
    {
        ValidateLanguage(primaryLanguage);

        this.primaryLanguage = primaryLanguage;
        this.technicalAllowance = 0;
    }

    // Constructor thứ hai
    public SoftwareEngineer(
        string id,
        string fullName,
        double baseSalary,
        string primaryLanguage,
        double technicalAllowance)
        : base(id, fullName, baseSalary)
    {
        ValidateLanguage(primaryLanguage);

        if (technicalAllowance < 0)
        {
            throw new ArgumentException(
                "Phụ cấp kỹ thuật không được âm."
            );
        }

        this.primaryLanguage = primaryLanguage;
        this.technicalAllowance = technicalAllowance;
    }

    // Ghi đè phương thức tính chi phí hàng tháng
    public override double CalculateMonthlyCost()
    {
        return GetBaseSalary() + technicalAllowance;
    }

    // Ghi đè phương thức hiển thị thông tin
    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"SoftwareEngineer | ID: {GetId()} | " +
            $"Name: {GetFullName()} | " +
            $"Base Salary: {GetBaseSalary():N0} | " +
            $"Language: {primaryLanguage} | " +
            $"Technical Allowance: {technicalAllowance:N0}"
        );
    }

    // Getter cho ngôn ngữ lập trình
    public string GetPrimaryLanguage()
    {
        return primaryLanguage;
    }

    // Getter cho phụ cấp kỹ thuật
    public double GetTechnicalAllowance()
    {
        return technicalAllowance;
    }

    // Kiểm tra ngôn ngữ lập trình
    private static void ValidateLanguage(string language)
    {
        if (string.IsNullOrWhiteSpace(language))
        {
            throw new ArgumentException(
                "Ngôn ngữ lập trình không được rỗng."
            );
        }
    }

    // In thông báo khi đối tượng bị thu hồi
    ~SoftwareEngineer()
    {
        Console.WriteLine(
            $"[Finalizer] SoftwareEngineer {GetId()} đã được thu hồi."
        );
    }
}