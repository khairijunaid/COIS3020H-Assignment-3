RWayTrie: R-Way Trie Implementation in C#
Project Title: R-Way Trie Data Structure Implementation
Author: Dinesh, Junaid, and Shahzan
Date: 2023-10-19
Technology: C#, .NET Framework, Console Application
Overview: This project implements an R-Way Trie data structure in C# that efficiently stores and retrieves strings with tree-like properties. It involves using array-based nodes to create a trie structure that supports insertion, searching, and prefix matching operations on words loaded from a text file.
Key Features: This project showcases skills in advanced data structures and algorithms using C#. It utilizes an R-Way Trie with 126-character support to create efficient string storage and retrieval systems. It demonstrates the ability to handle file I/O operations, implement interactive console interfaces, and optimize search operations for large word datasets.
Learning Outcomes: Mastery in C# programming and data structure implementation. Proficiency in creating efficient search algorithms and string processing systems. Skill in algorithm optimization and time complexity analysis.
Purpose: This project was developed to demonstrate advanced data structure implementation skills using C#. It reflects the ability to convert theoretical computer science concepts into practical applications for text processing and word searching scenarios.

Implementation
The primary data structure used is an R-Way Trie. This is a special data structure that stores strings with the properties of a tree. The code consists of the RWayTrieCode class which implements the following: Insert, Search, and PrefixMatch.
RWayTrieNode Class:
Description: Represents a node in R-Way Trie, containing an array of child nodes and a boolean flag indicating the end of a word.
Constructor: Initializes a new node with an array of 126 child nodes (RWayTrieNode[126]) and sets the end-of-word flag to false.
Time Complexity: O(1) for initialization.
Methods for RWayTrie:
1. Insert: This method inserts a word into the trie
Input: string word
Operation: Iterates through the trie and creates nodes to accommodate the insertion of the word
Time Complexity: O(n)
2. Search(string word): Searches for a word in the trie
Input: string word
Operation: Traverses the trie to find the input word, returning true if found.
Time Complexity: O(n)
3. PrefixMatch(string prefix): Find all words in a trie with a given prefix
Input: string prefix
Operation: Traverses the trie to find all words that start with the given prefix.
Time Complexity: O(p + m) for prefix match
