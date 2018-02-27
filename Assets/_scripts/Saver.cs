using System;
using FullSerializer;
using UnityEngine;

namespace ASLUNO
{
    public static class Saver
    {
        private static readonly fsSerializer _serializer = new fsSerializer();

        public static bool LoadData<T>(ref T loadMe)
        {
            bool retval = true;

            try
            {

                string key = typeof(T).FullName;
                string json = PlayerPrefs.GetString(key);
                Debug.LogFormat("Loading Data of Type ({0}): {1}", key, json);

                fsData data = fsJsonParser.Parse(json);
                object deserialized = null;
                _serializer.TryDeserialize(data, typeof(T), ref deserialized).AssertSuccessWithoutWarnings();
                loadMe = (T)deserialized;
                
            }
            catch (InvalidCastException e)
            {
                Debug.LogFormat("Saver.SaveData.InvalidCastException: {0}", e);
                retval = false;
            }
            catch (NullReferenceException e)
            {
                Debug.LogFormat("Saver.SaveData.NullReferenceException: {0}", e);
                retval = false;
            }
            catch (System.IO.IOException e)
            {
                Debug.LogFormat("Saver.SaveData.IOException: {0}", e);
                retval = false;
            }


            return retval;
            
        }

        public static bool SaveData<T>(T saveMe)
        {
            bool retval = true;

            try
            {
                string key = typeof(T).FullName;
                fsData data;
                _serializer.TrySerialize(saveMe, out data).AssertSuccessWithoutWarnings();
                string json = fsJsonPrinter.CompressedJson(data);
                Debug.LogFormat("Saving Data of Type ({0}): {1}", key, json);
                PlayerPrefs.SetString(key, json);

                if(!PlayerPrefs.HasKey(key))
                {
                    throw new Exception("PlayerPrefsSetKeyException");
                }
            }
            catch (InvalidCastException e)
            {
                Debug.LogFormat("Saver.SaveData.InvalidCastException: {0}", e);
                retval = false;
            }
            catch (NullReferenceException e)
            {
                Debug.LogFormat("Saver.SaveData.NullReferenceException: {0}", e);
                retval = false;
            }
            catch (System.IO.IOException e)
            {
                Debug.LogFormat("Saver.SaveData.IOException: {0}", e);
                retval = false;
            }


            return retval;
        }

       

        public static bool Test()
        {
            bool retval = true;
            
            Deck testDeck = new Deck();

            // first, let's run our deck's tests
            // to make sure our deck is working properly
            retval = testDeck.Test();

            
            if(retval)
            {
                // test to make sure we can save our deck class without any errors
                retval = SaveData(testDeck);
                TestRunner.LogTestResult(retval, "Saver.Test.1 Save A Test Deck Without Any Intrinsic Errors");
            }
            
            if(retval)
            {
                // test to make sure that we can load our deck class without any errors
                // we will empty the deck first to prevent any false positives in later tests
                testDeck.EmptyDeck();
                retval = LoadData(ref testDeck);
                TestRunner.LogTestResult(retval, "Saver.Test.2 Load A Test Deck Without Any Intrinsic Errors");

            }

            if(retval)
            {
                // test to make sure that our deck has the correct number of cards
                // should now have 3 cards
                retval = testDeck.GetCardCount() == 3;
                TestRunner.LogTestResult(retval, "Saver.Test.3 Loaded Deck Has Correct Number of Cards");
            }

            if(retval)
            {
                // test to make sure that a deck that has been saved and then reloaded has
                // an identical deck state as the deck that was first created
                // the topCard should still be the Blue 2
                Card topCard = testDeck.ViewTopCard();
                retval = topCard.Number() == 2 && topCard.Color() == unocolor.blue && topCard.Word() == unoword.none;
                TestRunner.LogTestResult(retval, "Saver.Test.3 Deck State Maintained After Save, Empty, and Load");
            }



            return retval;

        }

    }

    

}
