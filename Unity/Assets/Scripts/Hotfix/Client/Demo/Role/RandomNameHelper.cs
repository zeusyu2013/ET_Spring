namespace ET.Client
{
    public static class RandomNameHelper
    {
        public static string RandomName()
        {
            int count = RandomNameConfigCategory.Instance.DataList.Count;
            string familyName = RandomNameConfigCategory.Instance.DataList[RandomGenerator.RandomNumber(0, count)].FamilyName;
            string lastName = RandomNameConfigCategory.Instance.DataList[RandomGenerator.RandomNumber(0, count)].LastName;

            return $"{familyName}·{lastName}";
        }
    }
}