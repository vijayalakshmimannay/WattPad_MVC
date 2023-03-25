using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using WattPad.Models;

namespace WattPad.Repository
{
    public class BlogRL : IBlogRL
    {
        string dbpath = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WattPad;Integrated Security=True";

        SqlConnection sqlConnection;

        
        public BlogRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public List<BlogModel> blogmodel = new List<BlogModel>();

        public SqlConnection SqlConnection;
        
        public BlogModel AddBlog(BlogModel blog)
        {
            try
            {
               // string uniqueFileName = UploadedFile ((BlogModel)blog.ImagePath);
                sqlConnection = new SqlConnection(dbpath);
                SqlCommand command = new SqlCommand("SP_AddBlog", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                sqlConnection.Open();

                //command.Parameters.AddWithValue("@Id", blog.Id);
                command.Parameters.AddWithValue("@Title", blog.Title);
                command.Parameters.AddWithValue("@PublishDate", blog.Date);
                command.Parameters.AddWithValue("@Content", blog.Content);
                //command.Parameters.AddWithValue("@ImagePath", uniqueFileName);
                command.ExecuteNonQuery();
                return blog;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        //private string UploadedFile(BlogModel blog)
        //{
        //    string uniqueFileName = null;

        //    if (blog.ImagePath != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + blog.ImagePath.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            blog.ImagePath.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
    

        public IEnumerable<BlogModel> GetAllBlogs()
        {

            sqlConnection = new SqlConnection(dbpath);
            try
            {
                SqlCommand command = new SqlCommand("sp_GetAllBlogs ", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        blogmodel.Add(new BlogModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Date = reader["PublishDate"].ToString(),
                            Content = reader["Content"].ToString()
                        });
                    }
                    return blogmodel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }


        }

        public IEnumerable<BlogModel> GetAllBlogsbyId(int Id)
        {

            sqlConnection = new SqlConnection(dbpath);
            try
            {
                SqlCommand command = new SqlCommand("sp_GetAllBlogsbyId ", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();
                command.Parameters.AddWithValue("Id", Id);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        blogmodel.Add(new BlogModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Date = reader["PublishDate"].ToString(),
                            Content = reader["Content"].ToString()
                        });
                    }
                    return blogmodel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }


        }

        public BlogModel UpdateBlog(BlogModel blog)
        {
            try
            {
                sqlConnection = new SqlConnection(dbpath);
                SqlCommand command = new SqlCommand("SP_UpdateBlog", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();
                command.Parameters.AddWithValue("@Id", blog.Id);
                command.Parameters.AddWithValue("@Title", blog.Title);
                command.Parameters.AddWithValue("@PublishDate", blog.Date);
                command.Parameters.AddWithValue("@Content", blog.Content);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return blog;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public BlogModel Delete(BlogModel blog)
        {
            try
            {
                sqlConnection = new SqlConnection(dbpath);
                SqlCommand command = new SqlCommand("sp_DeleteBlog", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();
                command.Parameters.AddWithValue("@Id", blog.Id);
                var result = command.ExecuteNonQuery();
                return blog;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


    }
}
