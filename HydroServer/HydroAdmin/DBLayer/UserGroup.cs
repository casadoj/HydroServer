﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBLayer
{
    public class UserGroup
    {
        public DataTable GetUserGroupInfoList()
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select ug.usergroupid,ug.name,ug.datecreated,ur.ResourceConsumerName as Owner from UserGroup as ug inner join ResourceConsumer as ur on ug.OwnerId=ur.ResourceConsumerId;";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
            return dt;
        }

        public DataTable GetUserGroupList(int userId)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "select usergroupid from UserGroupResourceConsumer where ResourceConsumerId =" + userId + ";";
                cmd.CommandText = queryString;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
            return dt;
        }

        public void UserGroupAdd(int userId,int userGroupId)
        {
            string connectionStringin = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnectionin = new SqlConnection(connectionStringin);
            myConnectionin.Open();
            SqlCommand cmdin = new SqlCommand();
            cmdin.Connection = myConnectionin;
            try
            {
                string queryStringin = "insert into usergroupresourceconsumer values('" + userGroupId + "'," + userId + ",1,'12-12-2011');";
                cmdin.CommandText = queryStringin;
                cmdin.ExecuteNonQuery();

                 
            }
            catch (Exception em)
            {
            }
            myConnectionin.Close();
        }

        public void ReleaseGroupRows(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityDb"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;
                string queryString = "delete from UserGroupResourceConsumer where ResourceConsumerId =" + userId + ";";
                cmd.CommandText = queryString;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("this is not successful :" + e.Message.ToString());
            }
        }
     }

}

