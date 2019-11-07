using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Lab5
{
    public class DBTriangleSaver
    {
        private MySqlConnection connection;

        public DBTriangleSaver(string host, int port, string database, string username, string password)
        {
            this.connection =
                new MySqlConnection(
                    $"Server={host}; Database={database}; Port={port}; User Id={username}; Password={password}");

            connection.Open();
        }

        ~DBTriangleSaver()
        {
            connection.Close();
        }

        private bool HavePoint(Point point)
        {
            string command = $"SELECT COUNT(point_id) FROM triangles.points WHERE x = {point.X} AND y = {point.Y}";
            MySqlCommand sqlcmd = new MySqlCommand(command, connection);
            int count = Int32.Parse(sqlcmd.ExecuteScalar().ToString());

            return count != 0;
        }

        private int GetPointId(Point point)
        {
            string command = $"SELECT point_id FROM triangles.points WHERE x = {point.X}  AND y = {point.Y}";
            MySqlCommand sqlcmd = new MySqlCommand(command, connection);
            MySqlDataReader reader = sqlcmd.ExecuteReader();

            int result = 0;
            while (reader.Read())
            {
                result = Int32.Parse(reader[0].ToString());   
            }
            reader.Close();
            return result;
        }

        private bool HaveTriangle(Triangle triangle)
        {
            if (HavePoint(triangle.A) && HavePoint(triangle.B) && HavePoint(triangle.C))
            {
                int A = GetPointId(triangle.A);
                int B = GetPointId(triangle.B);
                int C = GetPointId(triangle.C);

                string command =
                    $"SELECT COUNT(triangle_num) FROM triangles.triangles WHERE A = {A} AND B = {B} AND C = {C}";
                MySqlCommand sqlcmd = new MySqlCommand(command, connection);
                int count = Int32.Parse(sqlcmd.ExecuteScalar().ToString());

                return count != 0;
            }

            return false;
        }

        private int createPoint(Point point)
        {
            if (!HavePoint(point))
            {
                string command = $"INSERT INTO triangles.points (x,y) VALUES ({point.X}, {point.Y})";
                MySqlCommand sqlcmd = new MySqlCommand(command, connection);
                sqlcmd.ExecuteNonQuery();
            }

            return GetPointId(point);
        }

        public void saveTriangle(Triangle triangle)
        {
            if (HaveTriangle(triangle)) return;

            int A = createPoint(triangle.A);
            int B = createPoint(triangle.B);
            int C = createPoint(triangle.C);

            string command = $"INSERT INTO triangles.triangles (A, B, C) VALUES ({A}, {B}, {C})";
            MySqlCommand sqlcmd = new MySqlCommand(command, connection);
            sqlcmd.ExecuteNonQuery();
        }

        public List<Triangle> getTriangles()
        {
            string command = "SELECT pA.x, pA.y, pB.x, pB.y, pC.x, pC.y FROM (" +
                             "(triangles.triangles AS tr INNER JOIN triangles.points AS pA ON tr.A = pA.point_id)" +
                             " INNER JOIN triangles.points AS pB ON tr.B = pB.point_id)" +
                             " INNER JOIN triangles.points AS pC ON tr.C = pC.point_id";

            MySqlCommand sqlcmd = new MySqlCommand(command, connection);
            MySqlDataReader reader = sqlcmd.ExecuteReader();

            List<Triangle> triangles = new List<Triangle>();
            while (reader.Read())
            {
                Point a = new Point(Int32.Parse(reader[0].ToString()), Int32.Parse(reader[1].ToString()));
                Point b = new Point(Int32.Parse(reader[2].ToString()), Int32.Parse(reader[3].ToString()));
                Point c = new Point(Int32.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()));
                triangles.Add(new Triangle(a,b,c));
            }
            
            reader.Close();
            return triangles;
        }
    }
}