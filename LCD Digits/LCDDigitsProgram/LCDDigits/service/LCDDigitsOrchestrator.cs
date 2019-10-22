﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.service
{
    class LCDDigitsOrchestrator
    {
        private readonly InputCapturer _inputCapturer;
        private readonly LCDConverter _lcdConverter;
        private readonly OutputRenderer _outputRenderer;

        
        public LCDDigitsOrchestrator()
        {
            _inputCapturer = new InputCapturer();
            _lcdConverter = new LCDConverter();
            _outputRenderer = new OutputRenderer();
        }

        public void StringToLCD()
        {
            var userInput = _inputCapturer.GetUserInput();
            var lcdLookup = _lcdConverter.LookupLCDNotation(userInput);
            _outputRenderer.renderCollection(lcdLookup);

        }

    }
}
