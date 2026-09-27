/********************************
Mã sinh viên: 202418931
Họ tên: Trần Thị Hà Lan
********************************/
using System;

// Lớp Employee biểu diễn một nhân sự trong hệ thống
public class Employee
{
    // Mã nhân sự
    private string id;

    // Họ tên nhân sự
    private string fullName;

    // Lương cơ bản
    private double baseSalary;

    // Constructor mặc định
    public Employee()
    {
        id = "UNKNOWN";
        fullName = "Unnamed employee";
        baseSalary = 0;
    }

    // Constructor với mã nhân sự và họ tên
    public Employee(string id, string fullName)
    {
        ValidateId(id);
        ValidateFullName(fullName);

        this.id = id;
        this.fullName = fullName;
        this.baseSalary = 0;
    }

    // Constructor với đầy đủ thông tin
    public Employee(string id, string fullName, double baseSalary)
    {
        ValidateId(id);
        ValidateFullName(fullName);
        ValidateSalary(baseSalary);

        this.id = id;
        this.fullName = fullName;
        this.baseSalary = baseSalary;
    }

    // Getter cho mã nhân sự
    public string GetId()
    {
        return id;
    }

    // Getter cho họ tên
    public string GetFullName()
    {
        return fullName;
    }

    // Getter cho lương cơ bản
    public double GetBaseSalary()
    {
        return baseSalary;
    }

    // Nạp chồng phương thức:
    // Tăng lương theo một số tiền cố định
    public void IncreaseSalary(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Giá trị tăng lương phải lớn hơn 0.");
        }

        baseSalary += amount;
    }

    // Nạp chồng phương thức:
    // Tăng lương theo phần trăm hoặc số tiền cố định
    public void IncreaseSalary(double value, bool byPercentage)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Giá trị tăng lương phải lớn hơn 0.");
        }

        if (byPercentage)
        {
            // Tăng theo tỷ lệ phần trăm
            baseSalary += baseSalary * value / 100.0;
        }
        else
        {
            // Tăng theo số tiền cố định
            baseSalary += value;
        }
    }

    // Tính chi phí nhân sự hàng tháng
    public virtual double CalculateMonthlyCost()
    {
        return baseSalary;
    }

    // Hiển thị thông tin nhân sự
    public virtual void DisplayInfo()
    {
        Console.WriteLine(
            $"Employee | ID: {id} | Name: {fullName} | " +
            $"Base Salary: {baseSalary:N0}"
        );
    }

    // In thông báo khi đối tượng bị thu hồi
    ~Employee()
    {
        Console.WriteLine($"[Finalizer] Employee {id} đã được thu hồi.");
    }

    // Kiểm tra mã nhân sự
    private static void ValidateId(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Mã nhân sự không được rỗng.");
        }
    }

    // Kiểm tra họ tên
    private static void ValidateFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Họ tên không được rỗng.");
        }
    }

    // Kiểm tra lương
    private static void ValidateSalary(double salary)
    {
        if (salary < 0)
        {
            throw new ArgumentException("Lương cơ bản không được âm.");
        }
    }
}