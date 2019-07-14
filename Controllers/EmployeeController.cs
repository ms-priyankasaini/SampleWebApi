using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleWebApi.Models;
using System.Data.Entity;
using System.Web.ModelBinding;

namespace SampleWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        EmpDBEntities db = new EmpDBEntities();
        // GET: 
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.employees.ToList().AsEnumerable());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage GetEmployee(int id)
        {
            try
            {
                Employee emp = db.employees.Find(id);

                if (emp == null)
                {
                    //sending response as error status code NOT FOUND with meaningful message.  
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not Found");
                }
                else
                {
                    //sending response as status code OK with Employee entity.  
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


        public HttpResponseMessage Post(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                
                        int max_id = db.employees.Max(e=>e.id);

                        emp.id = max_id + 1;
                        db.employees.Add(emp);
                        db.SaveChanges();

                        //return response status as successfully created with Employee entity 
                        var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, emp);

                        //Response message with request uri for checking purpose  
                        response.Headers.Location = new Uri(Request.RequestUri + emp.id.ToString());

                        return response;
                  }
                  else
                  {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error in Employee Creation");
                  }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }

        
        public HttpResponseMessage PutEmployee(Employee emp_modify)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee emp = db.employees.Find(emp_modify.id);

                    if (emp != null)
                    {
                        emp.last_name = emp_modify.last_name;
                        emp.department = emp_modify.department;
                        emp.job_title = emp_modify.job_title;
                        emp.email = emp_modify.email;
                        db.SaveChanges();

                        //return response status as successfully updated  
                        return Request.CreateResponse(HttpStatusCode.OK, "Employee Details Modified Successfully");
                    }
                    else
                    {
                        //return response error as NOT FOUND  with message.  
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Employee Not Found");
                    }
                }
                else
                {
                    //return response error as NOT FOUND  with message.  
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error in Employee Updation");
                }
            }
            catch(Exception ex)
            {
                    //return response error as NOT FOUND  with message.  
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Employee emp = db.employees.Find(id);

                if (emp != null)
                {
                    db.employees.Remove(emp);
                    db.SaveChanges();

                    //return response status as successfully deleted with Employee id  
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    //return response error as Not Found  with message.  
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Id : {0}, Not Found or Invalid " + id.ToString());
                }
            }
            catch (Exception ex)
            {
                //return response error as bad request  with exception message.  
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
