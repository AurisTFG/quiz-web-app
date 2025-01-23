import React, { useEffect, useState } from "react";
import { getHighScores } from "../api/quizApi";
import { QuizResultResponseDTO } from "../types/types";
import { List, ListItem, ListItemText, Typography } from "@mui/material";

const HighScores: React.FC = () => {
  const [highScores, setHighScores] = useState<QuizResultResponseDTO[]>([]);

  useEffect(() => {
    const fetchHighScores = async () => {
      const data = await getHighScores();
      setHighScores(data);
    };
    fetchHighScores();
  }, []);

  return (
    <div>
      <Typography variant="h4">High Scores</Typography>
      <List>
        {highScores.slice(0, 10).map((score, index) => (
          <ListItem
            key={index}
            style={{ color: index < 3 ? ["gold", "silver", "bronze"][index] : "black" }}
          >
            <ListItemText
              primary={`#${index + 1} - ${score.email} - ${score.score} points - ${new Date(
                score.submittedAt
              ).toLocaleString()}`}
            />
          </ListItem>
        ))}
      </List>
    </div>
  );
};

export default HighScores;
