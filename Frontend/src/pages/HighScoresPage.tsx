import React, { useEffect, useState } from "react";
import { getHighScores } from "../api/quizApi";
import { QuizResultResponseDTO } from "../types/types";
import { List, ListItem, ListItemText, Typography } from "@mui/material";
import Spinner from "../components/Spinner/Spinner";

const HighScoresPage: React.FC = () => {
  const [loading, setLoading] = useState(true);
  const [highScores, setHighScores] = useState<QuizResultResponseDTO[]>([]);

  useEffect(() => {
    const fetchHighScores = async () => {
      const data = await getHighScores();
      setHighScores(data);
      setLoading(false);
    };
    fetchHighScores();
  }, []);

  return (
    <div>
      <Typography variant="h4">High Scores</Typography>
      {loading ? (
        <Spinner />
      ) : (
        <List>
          {highScores.slice(0, 10).map((score, index) => (
            <ListItem
              key={index}
              style={{
                color:
                  index === 0 ? "gold" : index === 1 ? "silver" : index === 2 ? "#CD7F32" : "black",
              }}
            >
              <ListItemText
                primary={`#${index + 1} - ${score.email} - ${score.score} points - ${new Date(
                  score.submittedAt
                ).toLocaleString()}`}
              />
            </ListItem>
          ))}
        </List>
      )}
    </div>
  );
};

export default HighScoresPage;
