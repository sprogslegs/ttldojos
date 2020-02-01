﻿using AddressProcessing.CSV;
using NUnit.Framework;
using System;
using System.IO;

namespace AddressProcessing.Tests.FileOperations
{
    [TestFixture]
    public class CloseExtensionsTest
    {
        private const string _testFile = @"test_data\contacts.csv";

        [Test]
        public void CloseReaderExtensionClosesFile()
        {
            bool wasClosed;
            var csvReader = new CSVReader(File.OpenText(_testFile));
            
            csvReader.Close();

            try
            {
                FileStream fs =
                    new FileStream(_testFile, FileMode.Open);
                wasClosed = true;
                fs.Close();
            }
            catch (Exception)
            {
                wasClosed = false;
            }

            Assert.IsTrue(wasClosed);
        }
        
        [Test]
        public void CloseWriterExtensionClosesFile()
        {
            bool wasClosed;
            var csvWriter = new CSVWriter(); ;
            csvWriter.Open(_testFile);
            csvWriter.Close();

            try
            {
                FileStream fs =
                    new FileStream(_testFile, FileMode.Open);
                wasClosed = true;
                fs.Close();
            }
            catch (Exception)
            {
                wasClosed = false;
            }

            Assert.IsTrue(wasClosed);
        }

    }
}
