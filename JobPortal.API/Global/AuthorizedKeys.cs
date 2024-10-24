namespace JobPortal.API.Global;

public class AuthorizedKeys
{
    public static string Secret { get; set; } = "ThisKeyShouldBeVeryLongAndVerySecret";
    public static string Audience { get; set; } = "Teknorix-audience";
    public static string Issuer { get; set; } = "Teknorix-issuer";

}
