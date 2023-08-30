using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class TaskDAO : EmployeeContext
    {
        public static void AddTask(TASK task)
        {
            try
            {
                db.TASKs.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            try
            {
                TASK task = db.TASKs.First(x => x.ID == taskID);

                if (isAdmin)
                    task.TaskState = TaskStates.Approved;
                else
                    task.TaskState = TaskStates.Delivered;

                task.TaskDeliveryDate = DateTime.Today;

                db.SubmitChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public static void DeleteTask(int taskID)
        {
            try
            {
                TASK ts = db.TASKs.First(x => x.ID == taskID);
                db.TASKs.DeleteOnSubmit(ts);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TaskDetailDTO> GetTasks()
        {
            try
            {
                List<TaskDetailDTO> taskList = new List<TaskDetailDTO>();

                var list = (from t in db.TASKs
                            join s in db.TASKSTATEs on t.TaskState equals s.ID
                            join e in db.EMPLOYEEs on t.EmployeeID equals e.ID
                            join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                            join p in db.POSITIONs on e.PositionID equals p.ID
                            select new
                            {
                                employeeID = t.EmployeeID,
                                userNo = e.UserNo,
                                name = e.Name,
                                surname = e.Surname,
                                departmentName = d.DepartmentName,
                                positionName = p.PositionName,
                                departmentID = e.DepartmentID,
                                positionID = e.PositionID,
                                taskID = t.ID,
                                title = t.TaskTitle,
                                content = t.TaskContent,
                                taskStateName = s.StateName,
                                startDate = t.TaskStartDate,
                                deliveryDate = t.TaskDeliveryDate,
                                taskStateID = t.TaskState
                            }).OrderBy(x => x.startDate).ToList();

                foreach (var item in list)
                {
                    TaskDetailDTO dto = new TaskDetailDTO();

                    dto.TaskID = item.taskID;
                    dto.Title = item.title;
                    dto.Content = item.content;
                    dto.TaskStartDate = item.startDate;
                    dto.TaskDeliveryDate = item.deliveryDate;
                    dto.TaskStateName = item.taskStateName;
                    dto.TaskStateID = item.taskStateID;
                    dto.UserNo = item.userNo;
                    dto.Name = item.name;
                    dto.Surname = item.surname;
                    dto.DepartmentName = item.departmentName;
                    dto.PositionID = item.positionID;
                    dto.PositionName = item.positionName;
                    dto.EmployeeID = item.employeeID;

                    taskList.Add(dto);
                }

                return taskList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TASKSTATE> GetTaskStates()
        {
            return db.TASKSTATEs.ToList();
        }

        public static void UpdateTask(TASK task)
        {
            try
            {
                TASK ts = db.TASKs.First(x => x.ID == task.ID);

                ts.TaskTitle = task.TaskTitle;
                ts.TaskContent = task.TaskContent;
                ts.TaskState = task.TaskState;
                ts.EmployeeID = task.EmployeeID;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
