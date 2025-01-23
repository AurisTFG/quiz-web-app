import React, { useEffect, useState } from "react";
import { getHighScores } from "../api/quizApi";
import { QuizResultResponseDTO } from "../types/types";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  Paper,
} from "@mui/material";
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
      <Typography variant="h4" gutterBottom>
        High Scores
      </Typography>

      {loading ? (
        <Spinner />
      ) : (
        <TableContainer component={Paper} sx={{ boxShadow: 3 }}>
          <Table>
            <TableHead>
              <TableRow
                style={{
                  backgroundColor: "cyan",
                  color: "#fff",
                  fontWeight: "bold",
                }}
              >
                <TableCell align="center" style={{ fontSize: "1.2rem", padding: "16px" }}>
                  Rank
                </TableCell>
                <TableCell align="center" style={{ fontSize: "1.2rem", padding: "16px" }}>
                  Player
                </TableCell>
                <TableCell align="center" style={{ fontSize: "1.2rem", padding: "16px" }}>
                  Score
                </TableCell>
                <TableCell align="center" style={{ fontSize: "1.2rem", padding: "16px" }}>
                  Date
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {highScores.slice(0, 10).map((score, index) => (
                <TableRow
                  key={index}
                  style={{
                    backgroundColor:
                      index === 0
                        ? "gold"
                        : index === 1
                        ? "silver"
                        : index === 2
                        ? "#CD7F32"
                        : "transparent",
                  }}
                >
                  <TableCell align="center">{index + 1}</TableCell>
                  <TableCell align="center">{score.email}</TableCell>
                  <TableCell align="center">{score.score} points</TableCell>
                  <TableCell align="center">
                    {new Date(score.submittedAt).toLocaleString()}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      )}
    </div>
  );
};

export default HighScoresPage;
