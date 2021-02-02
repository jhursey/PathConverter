using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using PathConverter.Processors;
using PathConverter.Models;
using PathConverter.Interfaces;
using Moq;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PathConverter.Tests
{
    [TestClass]
    public class KeypathProcessorTests
    {
        KeypathProcessor processor;

        [TestInitialize]
        public void Init()
        {
            processor = new KeypathProcessor(new Mock<Serilog.ILogger>().Object);
        }

        [TestMethod]
        public void IsValidKeypath_NullInput()
        {
            List<string> inputs = null;

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValidKeypath_EmptyInput()
        {
            List<string> inputs = new List<string>();

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValidKeypath_Valid() 
        {
            List<string> inputs = new List<string>
            {
                "UUDDLLRRSS*"
            };

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsValidKeypath_Lowercase()
        {
            List<string> inputs = new List<string>
            {
                "uuddllrrss*" //Valid keys but in lowercase - not valid
            };

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValidKeypath_Invalid()
        {
            List<string> inputs = new List<string>
            {
                "uuddllrrss*x" //X is not a valid char 
            };

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValidKeypath_Return()
        {
            List<string> inputs = new List<string>
            {
                "uuddllrrss*\n" //return char should have been removed by file parsing. is not a valid char 
            };

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValidKeypath_WhiteSpace()
        {
            List<string> inputs = new List<string>
            {
                "uuddllrrss* " 
            };

            bool result = processor.IsValidKeypath(inputs);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertKeypath_KeyPathNull()
        {
            Keypath keypath = null;
            Keyboard keyboard = new Keyboard();

            string result = processor.ConvertKeypath(keypath, keyboard);

            result.Should().BeNull();
        }

        [TestMethod]
        public void ConvertKeypath_KeyboardNull()
        {
            Keypath keypath = new Keypath
            {
                Inputs = new List<string>
                {
                    "UUDDLLRRS*"
                }
            
            };

            Keyboard keyboard = null;

            string result = processor.ConvertKeypath(keypath, keyboard);

            result.Should().BeNull();
        }

        [TestMethod]
        public void ConvertKeypath_Valid()
        {
            Keypath keypath = new Keypath
            {
                Inputs = new List<string>
                {
                    "DR*R*SDLL*RR*LL*"
                }

            };

            Keyboard keyboard = new Keyboard();

            string result = processor.ConvertKeypath(keypath, keyboard);

            result.Should().Be("HI MOM");
        }

        [TestMethod]
        public void ConvertKeypath_MultipleInputs()
        {
            Keypath keypath = new Keypath
            {
                Inputs = new List<string>
                {
                    "DR*R*SDLL*RR*LL*",
                    "D*DRR**UUR*SDDLLL*RR*RRR*LLLL*SDD*R*"
                }

            };

            Keyboard keyboard = new Keyboard();

            string result = processor.ConvertKeypath(keypath, keyboard);

            result.Should().Be("HI MOM\r\nGOOD MORN Z1");
        }

        [TestMethod]
        public void ConvertKeypath_Whitespace()
        {
            Keypath keypath = new Keypath
            {
                Inputs = new List<string>
                {
                    "SSSS"
                }

            };

            Keyboard keyboard = new Keyboard();

            string result = processor.ConvertKeypath(keypath, keyboard);

            result.Should().BeEmpty(); //We trim whitespace so input of only whitespace will not be returned
        }

        [TestMethod]
        public void ConvertKeypath_WrapAround()
        {
            Keypath keypath = new Keypath
            {
                Inputs = new List<string>
                {
                    "L*",
                    "U*",
                    "RRRRRR*",
                    "DDDDDD*"
                }

            };

            Keyboard keyboard = new Keyboard();

            string result = processor.ConvertKeypath(keypath, keyboard);

            result.Should().Be("F\r\n5\r\nA\r\nA"); //Tests wrap around points to ensure transition is correct
        }

        [TestMethod]
        public void ParseFile_Exists()
        {
            Keypath result = processor.ParseFile(Constants.FilePaths.TESTINPUT);

            result.Should().NotBeNull();
            result.Inputs.Should().NotBeNullOrEmpty();
            result.Inputs.Count().Should().Be(3);
        }

        [TestMethod]
        public void ParseFile_NotExists()
        {
            var result = processor.ParseFile(" ");

            result.Should().BeNull();
        }
    }
}
