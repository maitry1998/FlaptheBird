using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System;

public class NewBehaviour2 : MonoBehaviour
{
    private string _constr = "URI=file:SQLTRY/NPCMaster2.db";
    private IDbConnection _connection;
    private IDbCommand _command;
    private IDataReader _dbr;
    string sql,sql2,question;
    int prev,newone;
    int counter1=1;
    public String qq = " ";
    public String qqq = " ";

    // Use this for initialization
    void Start()
    {
      
       // Debug.Log(_dbc.State.ToString());
       
    }
    public  void counter()
    {
        _connection = new SqliteConnection(_constr);
         _command = _connection.CreateCommand();
        _connection.Open();
        int abc1 = GameControl.instance.score;
        GameControl.instance.flagtest = 1;
        ////////////
        sql2 = "SELECT * from highscores where sid IN (select max(sid) from highscores) ";
        _command.CommandText = sql2;
        IDataReader reader = _command.ExecuteReader();
    
            reader.Read();
            question = reader.GetString(0);
            Debug.Log("question: " + question);
             prev= Convert.ToInt32(question);
        newone = prev + 1;
            reader.Close();
        //}
        /////////////////////////

        sql = "CREATE TABLE IF NOT EXISTS highscores (sid INT, score INT)";
        _command.CommandText = sql;
        _command.ExecuteNonQuery();

        sql = "INSERT INTO highscores (sid, score) VALUES ("+newone+","+abc1+" )";
        _command.CommandText = sql;
        _command.ExecuteNonQuery();


        //  IDataReader reader1 = _command.ExecuteReader();

        ///////////////////
        /*   while (reader1.Read())
           {
               if (reader1.NextResult())
               {


                   sql = "SELECT * from highscores ORDER BY score DESC  ";
                   _command.CommandText = sql;

                   question = reader1.GetString(1);
                   Debug.Log("highscore: " + question);

                   reader.Close();
               }
           }*/
        ///////////////////////
        sql = "SELECT * from highscores ORDER BY score DESC  ";
        _command.CommandText = sql;
        using (IDataReader reader1 = _command.ExecuteReader())
        {

            //   
           
            while (reader1.Read())
            {
                if (counter1 <= 6)
                {
                    question = reader1.GetString(1);
                    //  MessageBox.Show(reader.GetString(0), "Table1.Column1");
                    Debug.Log("highscore1: " + question);
                    counter1++;
                    qq = qq  +"  " +question;
                    Debug.Log("highscore1: " + qq);
                }
            }
            

            if (reader1.NextResult())
            {
                while (reader1.Read())
                {
                    //MessageBox.Show(reader.GetString(0), "Table2.Column2");
                    Debug.Log("going hre: " + question);
                }
            }
        }

        /* 
         _dbc = new SqliteConnection(_constr);
         _dbc.Open();
         Debug.Log(GameControl.instance.ScoreText.text);
        // int abc = Convert.ToInt64(GameControl.instance.ScoreText.text);
         int abc1= GameControl.instance.score;
         int A = 5;

        _dbcm.CommandText = "INSERT INTO gp (id, score) VALUES (4, 3)";
        _dbcm.ExecuteNonQuery();
         _dbr.Close();
         */
        //sql = "INSERT INTO highscores (name, score) VALUES ('Me', 3000)";
        //  _command.CommandText = sql;
        // _command.ExecuteNonQuery();

    }
    // Update is called once per frame 
    void Update()
    {
   
       
    }
}
