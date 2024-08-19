using InsXml;

namespace Test;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void JudgeTest()
    {
        Assert.AreEqual("KSLB", XMLSaver.SelectJudge("Krajsk� soud v �st� nad Labem � pobo�ka v Liberci"));
        
    }
    [TestMethod]
    public void JudgeTest2()
    {
        string test = XMLSaver.SelectJudge("Krajsk� soud v Ostrav� - pobo�ka v Olomouci");
        Assert.AreEqual("KSOL",test);

    }
    [TestMethod]
    public void JudgeTest3()
    {
        Assert.AreEqual("KSPA", XMLSaver.SelectJudge("Krajsk� soud v Hradci Kr�lov� � pobo�ka v Pardubic�ch"));

    }
    [TestMethod]
    public async Task ParseDataFromAnswerSOAPAsync()
    {
        DataIsirRC data = ParseXmlToData.CreateDataRC(await SearchSoap.SoapSearchingRC("930728/6076"));
        Assert.AreEqual("KSOL", XMLSaver.SelectJudge(data.NazevOrganizace));

    }
}