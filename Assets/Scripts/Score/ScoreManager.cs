namespace Archer
{

    public class ScoreManager
    {
        private readonly IScoreDisplay[] scoreDisplays;
        private float score;

        public ScoreManager(IScoreProvider[] scoreProviders, IScoreDisplay[] scoreDisplays)
        {
            foreach (var scoreProvider in scoreProviders)
            {
                scoreProvider.OnScoreAdded += ScoreProvider_OnScoreAdded;
            }

            this.scoreDisplays = scoreDisplays;
        }

        private void ScoreProvider_OnScoreAdded(float addedScore)
        {
            score += addedScore;

            foreach (var scoreDisplay in scoreDisplays)
            {
                scoreDisplay.UpdateDisplay(score, addedScore);
            }
        }
    }

}