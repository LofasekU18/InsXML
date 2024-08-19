using InsXml;

namespace Test;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void JudgeTest()
    {
        Assert.AreEqual("KSLB", XMLSaver.SelectJudge("Krajský soud v Ústí nad Labem – poboèka v Liberci"));
        
    }
    [TestMethod]
    public void JudgeTest2()
    {
        string test = XMLSaver.SelectJudge("Krajský soud v Ostravì - poboèka v Olomouci");
        Assert.AreEqual("KSOL",test);

    }
    [TestMethod]
    public void JudgeTest3()
    {
        Assert.AreEqual("KSPA", XMLSaver.SelectJudge("Krajský soud v Hradci Králové – poboèka v Pardubicích"));

    }
    [TestMethod]
    public async Task ParseDataFromAnswerSOAPAsync()
    {
        DataIsirRC data = ParseXmlToData.CreateDataRC(await SearchSoap.SoapSearchingRC("930728/6076"));
        Assert.AreEqual("KSOL", XMLSaver.SelectJudge(data.NazevOrganizace));

    }
}