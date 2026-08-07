using UnityEngine;

public class ErrorLogger : MonoBehaviour
{
    public static void LogError(int errorIndex, string varInfo = "")
    {
        HandleLogError(errorIndex, varInfo);
    }

    public static void LogError(string errorName, string varInfo = "")
    {
        int errorIndex = errorName switch
        {
            "Active" => 0,
            "Health" => 1,
            "Move Time" => 2,
            "Move Distance" => 3,
            "Brick Type" => 4,
            "Ranged Firerate" => 5,
            "Explosion Range" => 6,
            "Marker" => 7,
            "Data Count" => 8,
            _ => -1,
        };

        HandleLogError(errorIndex, varInfo);
    }

    private static void HandleLogError(int errorIndex, string varInfo)
    {
        
        switch (errorIndex) 
        {
            case 0:
                Debug.LogError("Non recognized activation detected.\n" +
                            "Make sure all activations are correctly written, " +
                            "as either T (true) or F (false).\n" +
                            "This was what was written: " + varInfo + "\n" +
                            "It will be defaulted to F (false).");
                return;

            case 1:
                Debug.LogError(GenericValueError("health", "int", varInfo,"1"));
                return;

            case 2:
                Debug.LogError(GenericValueError("move time", "float", varInfo, "3"));
                return;

            case 3:
                Debug.LogError(GenericValueError("move distance", "float", varInfo, "1"));
                return;

            case 4:
                Debug.LogError("Non recognized brick type detected.\n" +
                            "Make sure all types are correctly written, as either B, R or E.\n" +
                            "This was what was written: " + varInfo + "\n" +
                            "It will be defaulted to the basic brick type.");
                return;

            case 5:
                Debug.LogError(GenericValueError("ranged firerate", "float", varInfo, "3"));
                return;

            case 6:
                Debug.LogError(GenericValueError("explosion range", "vector2", varInfo, "[3,3]"));
                return;

            case 7:
                Debug.LogError("Something has gone wrong in the process. Make sure that all " +
                    "tags (markers) properly written correctly.\n"
                    + "This is the following tag (marker): " + varInfo + "\n" +
                    "Make sure its exactly as written like the others, matching case and all.\n" +
                    "It should be specifically the first one that is followed by data, as " +
                    "changing the second one (after the data) should not result in anything as " +
                    "It should immediatly be replaced by the next tag (marker).\n" +
                    "The process will resume as is, but this section will not be correctly assigned.");
                return;

            case 8:
                Debug.LogError("Something has gone wrong in the data counts.\n" +
                    "Make sure that all data lines have exactly 11 items.\n" +
                    "Data line count: " + varInfo + "\n" +
                    "If its smaller than 11, data will be added as default ones" +
                    "(will cause further errors)\n" +
                    "If its bigger than 11, excess data will be removed.");
                return;

            default: 
                Debug.LogError("Error index out of bounds, please make sure its within them.\n" +
                    "Received error index: " + errorIndex);
                return;
        }
    }

    private static string GenericValueError(string value, string valueType, string varInfo, string defaultValue)
    {
        string text = $"Non recognized {value} value detected.\n" +
                      $"Make sure all {value} values are correctly written, " +
                      $"as an {valueType}.\n" +
                      "This was what was written: " + varInfo + "\n" +
                      $"It will be defaulted to {defaultValue}.";
        return text;
    }
}
