namespace WeakestLink
{
    using System;

    public static class Extensions
    {
        /// <summary>
        /// Gets string via passed inputHandler and returns Int32 value taken out of it.
        /// If conversion or validation not passed shows message via outputHandler and calls inputHandler again.
        /// </summary>
        /// <param name="inputHandler">Method that requests new input.</param>
        /// <param name="assert">Validation assert.</param>
        /// <returns>Int32 value taken out of result of inputHandler</returns>
        public static int GetInt32(Func<string> inputHandler, Action<string> outputHadler, Predicate<int> assert = null)
        {
            if (inputHandler is null) throw new ArgumentException(nameof(inputHandler));

            if (assert is null)
            {
                assert = value => true;
            }

            int int32Value;
            bool isCorrect;

            do
            {
                string input = inputHandler.Invoke();

                bool convertedSuccessfully = int.TryParse(input, out int32Value);
                bool isValid = assert.Invoke(int32Value);

                isCorrect = convertedSuccessfully && isValid;
                if (!isCorrect)
                {
                    outputHadler?.Invoke("Incorrect input. Please, try again.");
                }
            }
            while (!isCorrect);

            return int32Value;
        }
    }
}
