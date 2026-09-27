/********************************
Mã sinh viên: 202418931
Họ tên: Trần Thị Hà Lan
********************************/
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== OOP Bai03: OVERLOADING =====");

        // ==========================================
        // TEST 1
        // Tạo hai Employee bằng hai constructor khác nhau
        // ==========================================

        Employee employee1 =
            new Employee("E01", "Nguyen Van An");

        Employee employee2 =
            new Employee("E02", "Tran Thi Binh", 15000000);

        Console.WriteLine("\n--- Test 1 ---");
        employee1.DisplayInfo();
        employee2.DisplayInfo();


        // ==========================================
        // TEST 2
        // Tạo hai SoftwareEngineer bằng hai constructor
        // ==========================================

        SoftwareEngineer engineer1 =
            new SoftwareEngineer(
                "E03",
                "Le Van Cuong",
                "C#"
            );

        SoftwareEngineer engineer2 =
            new SoftwareEngineer(
                "E04",
                "Pham Thi Dung",
                20000000,
                "Python",
                3000000
            );

        Console.WriteLine("\n--- Test 2 ---");
        engineer1.DisplayInfo();
        engineer2.DisplayInfo();


        // ==========================================
        // TEST 3
        // Tăng lương bằng số tiền cố định
        // ==========================================

        Console.WriteLine("\n--- Test 3 ---");

        Console.WriteLine(
            $"Salary before: {employee1.GetBaseSalary():N0}"
        );

        employee1.IncreaseSalary(2000000);

        Console.WriteLine(
            $"Salary after: {employee1.GetBaseSalary():N0}"
        );


        // ==========================================
        // TEST 4
        // Tăng lương theo phần trăm
        // ==========================================

        Console.WriteLine("\n--- Test 4 ---");

        Console.WriteLine(
            $"Salary before: {employee2.GetBaseSalary():N0}"
        );

        employee2.IncreaseSalary(10, true);

        Console.WriteLine(
            $"Salary after 10%: {employee2.GetBaseSalary():N0}"
        );


        // ==========================================
        // TEST 5
        // Tạo nhóm chưa có trưởng nhóm
        // ==========================================

        ProjectTeam team1 =
            new ProjectTeam(
                "P01",
                "Hospital Management System"
            );

        Console.WriteLine("\n--- Test 5 ---");
        team1.DisplayTeam();


        // ==========================================
        // TEST 6
        // Thêm Employee bằng addMember(employee)
        // ==========================================

        Console.WriteLine("\n--- Test 6 ---");

        bool result1 = team1.AddMember(employee1);

        Console.WriteLine(
            $"Add employee1: {result1}"
        );


        // ==========================================
        // TEST 7
        // Thêm SoftwareEngineer và đặt làm leader
        // ==========================================

        Console.WriteLine("\n--- Test 7 ---");

        bool result2 =
            team1.AddMember(engineer1, true);

        Console.WriteLine(
            $"Add engineer1 as leader: {result2}"
        );

        team1.DisplayTeam();


        // ==========================================
        // TEST 8
        // Thử thêm lại thành viên đã tồn tại
        // ==========================================

        Console.WriteLine("\n--- Test 8 ---");

        bool result3 =
            team1.AddMember(employee1);

        Console.WriteLine(
            $"Add employee1 again: {result3}"
        );


        // ==========================================
        // TEST 9
        // Kiểm tra đa hình
        // ==========================================

        Console.WriteLine("\n--- Test 9 ---");
        Console.WriteLine("Danh sách thành viên bằng lời gọi đa hình:");

        team1.DisplayTeam();


        // ==========================================
        // TEST 10
        // Tính tổng chi phí hàng tháng
        // ==========================================

        Console.WriteLine("\n--- Test 10 ---");

        double totalCost =
            team1.CalculateTotalMonthlyCost();

        Console.WriteLine(
            $"Total monthly cost: {totalCost:N0}"
        );


        // ==========================================
        // TEST 11
        // Thử xóa leader hiện tại
        // ==========================================

        Console.WriteLine("\n--- Test 11 ---");

        bool result4 =
            team1.RemoveMember(engineer1.GetId());

        Console.WriteLine(
            $"Remove current leader: {result4}"
        );


        // ==========================================
        // TEST 12
        // Đổi leader rồi xóa leader cũ
        // ==========================================

        Console.WriteLine("\n--- Test 12 ---");

        team1.ChangeLeader(employee1);

        bool result5 =
            team1.RemoveMember(engineer1.GetId());

        Console.WriteLine(
            $"Remove old leader after changing leader: {result5}"
        );

        team1.DisplayTeam();


        // ==========================================
        // TEST 13
        // Một Employee thuộc nhiều ProjectTeam
        // ==========================================

        Console.WriteLine("\n--- Test 13 ---");

        ProjectTeam team2 =
            new ProjectTeam(
                "P02",
                "Blood Donation Management"
            );

        team2.AddMember(employee1);

        Console.WriteLine(
            "employee1 belongs to both team1 and team2."
        );

        team2.DisplayTeam();


        // ==========================================
        // TEST 14 + 15
        // Hủy team2 nhưng Employee vẫn tồn tại
        // ==========================================

        Console.WriteLine("\n--- Test 14 ---");

        CreateAndDestroyTeam(employee2);

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("ProjectTeam thứ hai đã được thu hồi.");

        Console.WriteLine("\n--- Test 15 ---");

        Console.WriteLine(
            "Kiểm tra nhân sự vẫn tồn tại sau khi ProjectTeam bị thu hồi:"
        );

        employee2.DisplayInfo();

        Console.WriteLine("\n===== END =====");
    }

    // Tạo một ProjectTeam trong block cục bộ
    static void CreateAndDestroyTeam(Employee employee)
    {
       ProjectTeam team2 = new ProjectTeam(
           "P02",
           "Temporary Project"
       );

       team2.AddMember(employee);

       Console.WriteLine("Nhóm thứ hai:");
       team2.DisplayTeam();
    }
}