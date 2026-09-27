/********************************
Mã sinh viên: 202418931
Họ tên: Trần Thị Hà Lan
********************************/
using System;
using System.Collections.Generic;

// Lớp ProjectTeam quản lý một nhóm dự án
public class ProjectTeam
{
    // Mã dự án
    private string projectCode;

    // Tên dự án
    private string projectName;

    // Trưởng nhóm
    // Đây là liên kết không sở hữu
    private Employee? leader;

    // Danh sách thành viên
    // Các Employee cũng không thuộc quyền sở hữu của ProjectTeam
    private List<Employee> members;

    // Constructor tạo nhóm chưa có trưởng nhóm
    public ProjectTeam(string projectCode, string projectName)
    {
        if (string.IsNullOrWhiteSpace(projectCode))
        {
            throw new ArgumentException(
                "Mã dự án không được rỗng."
            );
        }

        if (string.IsNullOrWhiteSpace(projectName))
        {
            throw new ArgumentException(
                "Tên dự án không được rỗng."
            );
        }

        this.projectCode = projectCode;
        this.projectName = projectName;
        this.leader = null;
        this.members = new List<Employee>();
    }

    // Constructor tạo nhóm và thiết lập trưởng nhóm
    public ProjectTeam(
        string projectCode,
        string projectName,
        Employee leader)
        : this(projectCode, projectName)
    {
        this.leader = leader;

        // Trưởng nhóm đồng thời phải là thành viên
        members.Add(leader);
    }

    // Getter mã dự án
    public string GetProjectCode()
    {
        return projectCode;
    }

    // Getter tên dự án
    public string GetProjectName()
    {
        return projectName;
    }

    // Thêm thành viên thông thường
    public bool AddMember(Employee employee)
    {
        if (Contains(employee.GetId()))
        {
            return false;
        }

        members.Add(employee);
        return true;
    }

    // Nạp chồng AddMember:
    // Nếu makeLeader = true thì nhân sự trở thành trưởng nhóm
    public bool AddMember(
        Employee employee,
        bool makeLeader)
    {
        if (Contains(employee.GetId()))
        {
            // Nếu đã tồn tại nhưng được yêu cầu làm leader,
            // có thể đổi leader mà không thêm lần nữa
            if (makeLeader)
            {
                leader = employee;
            }

            return false;
        }

        members.Add(employee);

        if (makeLeader)
        {
            leader = employee;
        }

        return true;
    }

    // Kiểm tra nhân sự có trong nhóm hay không
    public bool Contains(string employeeId)
    {
        foreach (Employee employee in members)
        {
            if (employee.GetId() == employeeId)
            {
                return true;
            }
        }

        return false;
    }

    // Đổi trưởng nhóm
    public void ChangeLeader(Employee employee)
    {
        // Trưởng nhóm mới phải thuộc danh sách thành viên
        if (!Contains(employee.GetId()))
        {
            members.Add(employee);
        }

        leader = employee;
    }

    // Xóa thành viên theo mã
    public bool RemoveMember(string employeeId)
    {
        // Không được xóa trưởng nhóm hiện tại
        if (leader != null &&
            leader.GetId() == employeeId)
        {
            return false;
        }

        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].GetId() == employeeId)
            {
                members.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    // Tính tổng chi phí nhân sự hàng tháng
    public double CalculateTotalMonthlyCost()
    {
        double total = 0;

        foreach (Employee employee in members)
        {
            // Gọi phương thức virtual/override
            total += employee.CalculateMonthlyCost();
        }

        return total;
    }

    // Hiển thị thông tin nhóm
    public void DisplayTeam()
    {
        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine($"Project Code: {projectCode}");
        Console.WriteLine($"Project Name: {projectName}");

        if (leader == null)
        {
            Console.WriteLine("Leader: Chưa có");
        }
        else
        {
            Console.WriteLine(
                $"Leader: {leader.GetFullName()}"
            );
        }

        Console.WriteLine("Members:");

        foreach (Employee employee in members)
        {
            employee.DisplayInfo();
        }

        Console.WriteLine(
            $"Total Monthly Cost: " +
            $"{CalculateTotalMonthlyCost():N0}"
        );

        Console.WriteLine("================================");
    }

    // In thông báo khi đối tượng bị thu hồi
    // Chỉ thu hồi cấu trúc List nội bộ,
    // không hủy các đối tượng Employee.
    ~ProjectTeam()
    {
        Console.WriteLine(
            $"[Finalizer] ProjectTeam {projectCode} đã được thu hồi."
        );
    }
}