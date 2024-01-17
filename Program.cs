using System.IO;
using System.Text;

namespace RWayTrieCode
{
    // Class representing a node in RWayTrie
    public class RWayTrieNode
    {
        public RWayTrieNode[] Children;
        public bool IsEndOfWord;

        // Constructor for RWayTrieNode
        // Initializes a node with an array of children and a boolean to indicate the end of a word
        // Time Complexity: O(1) - Constant time for initialization
        public RWayTrieNode()
        {
            Children = new RWayTrieNode[126];
            IsEndOfWord = false;
        }
    }

    // Class representing the RWayTrie
    public class RWayTrie
    {
        private RWayTrieNode root;

        // Constructor for RWayTrie
        // Initializes the trie with a root node
        // Time Complexity: O(1) - Constant time for initializing the root node
        public RWayTrie()
        {
            root = new RWayTrieNode();
        }

        // Public method to insert a word into the trie
        // Checks if the word already exists; if not, calls InsertTrie to insert the word
        // Time Complexity: O(n) - Linear in the length of the word
        public void Insert(string word)
        {
            if (Search(word))
            {
                Console.WriteLine(word + " already exists in trie");
                return;
            }
            InsertTrie(word);
        }

        // Private helper method to insert a word into the trie
        // Traverses each character in the word, creating new nodes as needed
        // Time Complexity: O(n) - Linear in the length of the word
        private void InsertTrie(string word)
        {
            RWayTrieNode curr = root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = (int)word[i];
                if (index == -1)
                {
                    Console.WriteLine("This character: " + word[i] + " is not allowed, and will be skipped");
                    continue;
                }
                if (curr.Children[index] == null)
                {
                    curr.Children[index] = new RWayTrieNode();
                }
                curr = curr.Children[index];
            }

            curr.IsEndOfWord = true;
        }

        // Public method to search for a word in the trie
        // Returns true if the word is found, false otherwise
        // Time Complexity: O(n) - Linear in the length of the word
        public bool Search(string word)
        {
            return SearchTrie(word);
        }

        // Private helper method to search for a word in the trie
        // Traverses the trie to determine if the specific word exists
        // Time Complexity: O(n) - Linear in the length of the word
        private bool SearchTrie(string word)
        {
            RWayTrieNode curr = root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = (int)word[i];

                if (index == -1)
                {
                    Console.WriteLine("This character: " + word[i] + " is not allowed, and will be skipped");
                    continue;
                }

                if (curr.Children[index] == null)
                {
                    return false;
                }

                curr = curr.Children[index];
            }

            return curr.IsEndOfWord;
        }

        // Public method to find and display all words in the trie with a given prefix
        // Time Complexity: O(p + m) - Linear in the length of the prefix and the matching words
        public void PrefixMatch(string prefix)
        {
            RWayTrieNode curr = root;
            StringBuilder prefixBuilder = new StringBuilder();
            foreach (char c in prefix)
            {
                int index = (int)c;
                if (index == -1)
                {
                    Console.WriteLine("This character: " + c + " is not allowed, and will be skipped");
                    return;
                }
                if (curr.Children[index] == null)
                {
                    Console.WriteLine("No words with the given prefix.");
                    return;
                }
                prefixBuilder.Append(c);
                curr = curr.Children[index];
            }

            FindWordsWithPrefix(curr, prefixBuilder);
        }

        // Private helper method to recursively find and print all words in the trie that start with a given prefix
        // Time Complexity: O(m) - Linear in the number of characters in the matching words
        private void FindWordsWithPrefix(RWayTrieNode node, StringBuilder currentWord)
        {
            if (node == null)
                return;

            if (node.IsEndOfWord)
            {
                Console.WriteLine(currentWord.ToString());
            }

            for (int i = 0; i < node.Children.Length; i++)
            {
                if (node.Children[i] != null)
                {
                    currentWord.Append((char)i);
                    FindWordsWithPrefix(node.Children[i], currentWord);
                    currentWord.Length--;
                }
            }
        }
    }

    // Main class to demonstrate the use of RWayTrie
    class Program
    {
        static void Main(string[] args)
        {
            RWayTrie trie1 = new RWayTrie();

            // Reading words from a file and inserting them into the trie
            StreamReader reader = new StreamReader("testfile.txt");
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                trie1.Insert(line);
            }
            reader.Close();

            // Prompting user to enter a prefix for searching words in the trie
            Console.WriteLine("Enter a prefix to search for matching words (Enter 'exit' to quit):");

            while (true)
            {
                string prefix = Console.ReadLine();

                if (prefix == null)
                {
                    Console.WriteLine("Please try again and enter a prefix or 'exit' to quit");
                    continue;
                }

                if (prefix.ToLower() == "exit")
                    break;

                Console.WriteLine("\nWords matching the prefix:");
                trie1.PrefixMatch(prefix);
                Console.WriteLine("\nEnter a prefix to search for matching words (Enter 'exit' to quit):");
            }
        }
    }
}
