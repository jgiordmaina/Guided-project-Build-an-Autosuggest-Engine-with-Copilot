namespace TrieDictionaryTest;

[TestClass]
public class TrieTest
{
    
// Test that a word is inserted in the trie
    [TestMethod]
    public void InsertWord()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        Assert.IsTrue(trie.Search("hello"));
    }

    // Test that a word is not inserted twice in the trie
    [TestMethod]
    public void InsertWordTwice()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        Assert.IsFalse(trie.Insert("hello"));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void DeleteWord()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Delete("hello");
        Assert.IsFalse(trie.Search("hello"));
    }
    
    // Test that a word is not deleted from the trie if it is not present
    [TestMethod]
    public void DeleteWordNotPresent()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Delete("world");
        Assert.IsTrue(trie.Search("hello"));
    }
    
    // Test that a word is deleted from the trie if it is a prefix of another word
    [TestMethod]
    public void DeleteWordPrefix()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Insert("hell");
        trie.Delete("hello");
        Assert.IsTrue(trie.Search("hell"));
    }

    // Test AutoSuggest for the prefix "cat" not present in the 
    // trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggest()
    {
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");
        List<string> suggestions = trie.AutoSuggest("cat");
        Assert.AreEqual(3, suggestions.Count);
        Assert.IsTrue(suggestions.Contains("catastrophe"));
        Assert.IsTrue(suggestions.Contains("catatonic"));
        Assert.IsTrue(suggestions.Contains("caterpillar"));
    }

    // Test GetSpellingSuggestions for a word not present in the trie
    [TestMethod]
    public void SpellingSuggestions()
    {
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");
        List<string> suggestions = trie.GetSpellingSuggestions("catastroph");
        Assert.AreEqual(1, suggestions.Count);
        Assert.IsTrue(suggestions.Contains("catastrophe"));
    }

}