using System;
using System.Collections.Generic;

namespace PathConverter {
	class KeypadEvaluator {
		private char[,] keypadCharacters;
		private Dictionary<char, Action<EvaluationState, char[,]>> keypathTypeEvaluationFunctionMap;

		public KeypadEvaluator() : this(
			new char[,] {
				{'A', 'B', 'C', 'D', 'E', 'F'},
				{'G', 'H', 'I', 'J', 'K', 'L'},
				{'M', 'N', 'O', 'P', 'Q', 'R'},
				{'S', 'T', 'U', 'V', 'W', 'X'},
				{'Y', 'Z', '1', '2', '3', '4'},
				{'5', '6', '7', '8', '9', '0'},
			}, 
			new Dictionary<char, Action<EvaluationState, char[,]>>() {
				{ 'U', 
					(state, keypadCharacters) => {
						if (--state.yIndex < 0) {
							state.yIndex = keypadCharacters.GetLength(1) - 1;
						}
					}
				},
				{ 'D', 
					(state, keypadCharacters) => {
						if (++state.yIndex >= keypadCharacters.GetLength(1)) {
							state.yIndex = 0;
						}
					}
				},
				{ 'L', 
					(state, keypadCharacters) => {
						if (--state.xIndex < 0) {
							state.xIndex = keypadCharacters.GetLength(0) - 1;
						}
					}
				},
				{ 'R', 
					(state, keypadCharacters) => {
						if (++state.xIndex >= keypadCharacters.GetLength(0)) {
							state.xIndex = 0;
						}
					}
				},
				{
					'S', (state, keypadCharacters) => { state.result += ' '; }
				},
				{
					'*', (state, keypadCharacters) => { state.result += keypadCharacters[state.yIndex, state.xIndex]; }
				}
			})
		{}

		public KeypadEvaluator(char[,] keypadCharacters, Dictionary<char, Action<EvaluationState, char[,]>> keypathTypeEvaluationFunctionMap) {
			this.keypadCharacters = keypadCharacters;
			this.keypathTypeEvaluationFunctionMap = keypathTypeEvaluationFunctionMap;
		}

		public string Evaluate(string keypathInputs) {
			EvaluationState evaluation = new EvaluationState();

			foreach (char character in keypathInputs) {
				if (keypathTypeEvaluationFunctionMap.ContainsKey(character)) {
					keypathTypeEvaluationFunctionMap[character].Invoke(evaluation, keypadCharacters);
				}
			}
			
			return evaluation.result;
		}
	}
	public class EvaluationState {
		public int yIndex;
		public int xIndex;
		public string result;
	}
}
