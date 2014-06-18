using System;

public class ExamResult
{
    private int grade = 0;
    public int Grade 
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (this.Grade < 0 || this.Grade > 100)
            {
                throw new ArgumentOutOfRangeException("grade cant be < 0 or > 100");
            }

            this.grade = value;
        }
    }

    private int minGrade = 0;
    public int MinGrade 
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (value < 0 )
            {
                throw new ArgumentOutOfRangeException("mingrade cant be < 0");
            }

            this.minGrade = value;
        }
    }

    private int maxGrade = 100;
    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException("maxgrade cant be <= mingrade");
            }

            this.maxGrade = value;
        }
    }

    private string comments = null;
    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("comments cant be empty or null");
            }

            this.comments = value;
        }
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
