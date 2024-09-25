using System.Text;

DDCreator.CreateFieldEmbeddedSliderWithNAOption();

public static class DDCreator
{
    public static void CreateFieldEmbeddedSliderWithNAOption()
    {
        Dictionary<string, string> questions = new Dictionary<string, string>();
        questions.Add("cses_dumps", "1. Keep from getting down in the dumps.");
        questions.Add("cses_talk_pos", "2. Talk positively to yourself.");
        questions.Add("cses_sort_out", "3. Sort out what can be changed, and what can not be changed.");
        questions.Add("cses_emot_supp", "4. Get emotional support from friends and family.");
        questions.Add("cses_find_sol", "5. Find solutions to your most difficult problems.");
        questions.Add("cses_break_prob", "6. Break an upsetting problem down into smaller parts.");
        questions.Add("cses_opts_open", "7. Leave options open when things get stressful.");
        questions.Add("cses_make_plan", "8. Make a plan of action and follow it when confronted with a problem. ");
        questions.Add("cses_new_hobby", "9. Develop new hobbies or recreations.");
        questions.Add("cses_mind_off", "10. Take your mind off unpleasant thoughts.");
        questions.Add("cses_look4_good", "11. Look for something good in a negative situation.");
        questions.Add("cses_feel_sad", "12. Keep from feeling sad.");
        questions.Add("cses_others_pov", "13. See things from the other person's point of view during a heated argument.");
        questions.Add("cses_try_other_sol", "14. Try other solutions to your problems if your first solutions don't work.");
        questions.Add("cses_stop_unpleasant", "15. Stop yourself from being upset by unpleasant thoughts.");
        questions.Add("cses_new_friends", "16. Make new friends.");
        questions.Add("cses_friends_help", "17. Get friends to help you with the things you need. ");
        questions.Add("cses_positive4_self", "18. Do something positive for yourself when you are feeling discouraged.");
        questions.Add("cses_unpleas_thoughts", "19. Make unpleasant thoughts go away. ");
        questions.Add("cses_1part_prob", "20. Think about one part of the problem at a time.");
        questions.Add("cses_visualize_activity", "21. Visualize a pleasant activity or place.");
        questions.Add("cses_feel_lonely", "22. Keep yourself from feeling lonely.");
        questions.Add("cses_pray", "23. Pray or meditate.");
        questions.Add("cses_emot_support", "24. Get emotional support from community organizations or resources. ");
        questions.Add("cses_stand_ground", "25. Stand your ground and fight for what you want.");
        questions.Add("cses_resist_haste", "26. Resist the impulse to act hastily when under pressure.");

        Writer output = new Writer();
        output.Init(@"C:\Users\paul\Downloads\dd.csv");

        output.Write($"\"Variable/FieldName\",\"FormName\",\"SectionHeader\",\"FieldType\",\"FieldLabel\",\"Choices,Calculations,ORSliderLabels\",\"FieldNote\",\"TextValidationTypeORShowSliderNumber\",\"TextValidationMin\",\"TextValidationMax\",\"Identifier?\",\"BranchingWriteic(Showfieldonlyif...)\",\"RequiredField?\",\"CustomAlignment\",\"QuestionNumber(surveysonly)\",\"MatrixGroupName\",\"MatrixRanking?\",\"FieldAnnotation\"");

        foreach(var q in questions)
        {
            output.Write($"{q.Key}_host,coping_self_efficacy_scale,,descriptive,\"<div class=\"\"rich-text-field-label\"\"><table style=\"\"border-collapse: collapse; width: 99.9717%;\"\" border=\"\"0\"\"> <tbody> <tr> <td style=\"\"width: 99.9734%;\"\" colspan=\"\"2\"\">{q.Value}</td> </tr> <tr> <td style=\"\"width: 72%;\"\"><span style=\"\"font-weight: normal;\"\">{{{q.Key}}}</span></td> <td style=\"\"width: 28%; text-align: right;\"\"><span style=\"\"font-weight: normal;\"\">{{{q.Key}_na}}</span></td> </tr> </tbody> </table></div>\",,,,,,,,,,,,,");
            output.Write($"{q.Key},coping_self_efficacy_scale,,slider,\"{q.Value}\",\"1 | 5 | 10\",,,,10,,\"[{q.Key}_na(99)] <> '1'\",y,RH,,,,");
            output.Write($"{q.Key}_na,coping_self_efficacy_scale,,checkbox,,\"99, Choose not to answer\",,,,,,,,RH,,,,");
        }

        output.Close();
    }
}

public class Writer
{
    private FileStream? stream;
    private StreamWriter? outFile;

    public void Init(string fileName)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            stream = new FileStream(fileName, FileMode.Append);
            outFile = new StreamWriter(stream, Encoding.UTF8);
        }
    }
    public void Close()
    {
        if (outFile != null)
        {
            outFile.Flush();
            outFile.Close();
            outFile.Dispose();
        }
        if (stream != null)
        {
            stream.Dispose();
        }
    }

    public void Write(string Message)
    {
        string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        outFile.WriteLine($"{Message}");
    }
}
