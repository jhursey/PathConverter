using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PathConverter.Models;
using Serilog;
using PathConverter.Interfaces;

namespace PathConverter.Processors
{
    /// <summary>
    /// Processes conversion of keypaths to valid text
    /// </summary>
    public class KeypathProcessor
    {
        readonly ILogger _log;

        public KeypathProcessor(ILogger log)
        {
            _log = log;
        }

        /// <summary>
        /// Given a filepath, parses the file and returns a Keypath with the input from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Keypath ParseFile(string path)
        {
            if (!File.Exists(path))
            {
                _log.Information($"KeypathProcessor::ParseFile() File: '{path}' does not exist.");
               return null;
            }

            return new Keypath(File.ReadLines(path).ToList());
        }

        /// <summary>
        /// Given a keypath and a keyboard, converts and returns the output of the keypath
        /// </summary>
        /// <param name="keypath"></param>
        /// <param name="keyboard"></param>
        /// <returns></returns>
        public string ConvertKeypath(IKeypath keypath, IKeyboard keyboard)
        {
            if (keypath == null || !IsValidKeypath(keypath.Inputs))
            {
                _log.Information($"KeypathProcessor::ConvertKeypath() No valid input.");
                return null;
            }
            else if (keyboard?.Keys == null || !keyboard.Keys.Any())
            {
                _log.Information($"KeypathProcessor::ConvertKeypath() No valid keyboard.");
                return null;
            }

            StringBuilder response = new StringBuilder();

            foreach (string input in keypath.Inputs)
            {
                Cursor cursor = new Cursor();

                foreach (char character in input)
                {
                    switch (character)
                    {
                        case Constants.Keypaths.UP:
                            cursor = cursor.KeyUp();
                            break;
                        case Constants.Keypaths.DOWN:
                            cursor = cursor.KeyDown();
                            break;
                        case Constants.Keypaths.LEFT:
                            cursor = cursor.KeyLeft();
                            break;
                        case Constants.Keypaths.RIGHT:
                            cursor = cursor.KeyRight();
                            break;
                        case Constants.Keypaths.SPACE:
                            response.Append(" ");
                            break;
                        case Constants.Keypaths.SELECT:
                            response.Append(keyboard.Keys[cursor.Y][cursor.X]);
                            break;
                    }
                }

                response.AppendLine();
            }

            _log.Information("KeypathProcessor::ConvertKeypath() Conversion Successful");
            return response?.ToString().Trim();
        }

        /// <summary>
        /// Validates the given inputs to ensure the keypath is valid. returns a boolean value
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public bool IsValidKeypath(List<string> inputs)
        {
            if (inputs == null || !inputs.Any())
            {
                _log.Information($"KeypathProcessor::KeypathIsValid() No valid inputs");
                return false;
            }

            foreach(string input in inputs)
            {
                foreach (char character in input)
                {
                    switch (character)
                    {
                        case Constants.Keypaths.UP:
                        case Constants.Keypaths.DOWN:
                        case Constants.Keypaths.LEFT:
                        case Constants.Keypaths.RIGHT:
                        case Constants.Keypaths.SPACE:
                        case Constants.Keypaths.SELECT:
                            break;
                        default:
                            _log.Information($"KeypathProcessor::KeypathIsValid() Invalid character '{character}' detected at index {input.IndexOf(character)}.");
                            return false;
                    }
                }
            }

            _log.Information("KeypathProcessor::KeypathIsValid() Valid Input");
            return true;
        }
    }
}
