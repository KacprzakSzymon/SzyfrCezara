using SzyfrCezaraApp;

namespace Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Podstawa()
        {
            string plainText = "abc";
            int key = 3;
            string expected = "def";

            string actual = CaesarCipher.Encrypt(plainText, key);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LiteryZkoncaAlfabetu()
        {
            string plainText = "xyz";
            int key = 3;
            string expected = "abc";

            string actual = CaesarCipher.Encrypt(plainText, key);

            Assert.AreEqual(expected, actual);
        }

        // Test 3: Odszyfrowywanie (klucz ujemny)
        [TestMethod]
        public void KluczUjemny()
        {
            string plainText = "def";
            int key = -3;
            string expected = "abc";

            string actual = CaesarCipher.Encrypt(plainText, key);

            Assert.AreEqual(expected, actual);
        }

        // Test 4: Klucz większy niż długość alfabetu
        [TestMethod]
        public void KluczWiekszyNizAlfabet()
        {
            string plainText = "abc";
            int key = 29;
            string expected = "def";

            string actual = CaesarCipher.Encrypt(plainText, key);

            Assert.AreEqual(expected, actual);
        }

        // Test 5: Spacja w tekście
        [TestMethod]
        public void SpacjaWtekscie()
        {
            string plainText = "ab cd";
            int key = 2;
            string expected = "cd ef";

            string actual = CaesarCipher.Encrypt(plainText, key);

            Assert.AreEqual(expected, actual);
        }
    }
}
