using WebAppTest.CustomAttrributes;

namespace WebAppTest.Services
{
    public interface ITestA
    {
        [LogBeforeAttribute]
        [LogAfterAttribute]
        void Show();
    }
}
