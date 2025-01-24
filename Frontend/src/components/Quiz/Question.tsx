import React from "react";
import { Paper, Typography, Box } from "@mui/material";

interface QuestionProps {
  question: string;
  children: React.ReactNode;
}

const Question: React.FC<QuestionProps> = ({ question, children }) => {
  return (
    <Paper
      sx={{
        backgroundColor: "#f9f9f9",
        padding: "20px",
        borderRadius: "12px",
        boxShadow: 2,
        marginBottom: "20px",
        minHeight: "120px",
      }}
    >
      <Typography
        variant="h6"
        sx={{
          fontWeight: "bold",
          marginBottom: "15px",
          fontSize: "18px",
          color: "#333",
        }}
      >
        {question}
      </Typography>
      <Box>{children}</Box>
    </Paper>
  );
};

export default Question;
