using Microsoft.Maui.Storage;
namespace Mockup;
public class GenerateCode()
{

    public static int GenerateAndStoreCode()
    {
        // Generate a random 4-digit code
        Random random = new Random();
        int code = random.Next(1000, 9999);

        // Store the code and the current timestamp in Preferences
        Preferences.Set("verification_code", code);
        Preferences.Set("code_timestamp", DateTime.UtcNow.ToString());
        return code;
    }

    public static bool ValidateCode(int inputCode)
    {
        int storedCode = Preferences.Get("verification_code", 0);
        string timestampString = Preferences.Get("code_timestamp", string.Empty);

        if (!string.IsNullOrEmpty(timestampString) && DateTime.TryParse(timestampString, out DateTime storedTime))
        {
            if ((DateTime.UtcNow - storedTime).TotalSeconds > 120)
            {
                // Code has expired, remove it from Preferences
                Preferences.Remove("verification_code");
                Preferences.Remove("code_timestamp");
                return false;
            }

            if (storedCode == inputCode)
            {
                // Code is valid, remove it from Preferences
                Preferences.Remove("verification_code");
                Preferences.Remove("code_timestamp");
                return true;
            }
        }

        // Code is invalid or expired
        return false;
    }


}