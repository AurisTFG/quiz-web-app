import React from "react";
import { TextField } from "@mui/material";
import Question from "./Question";

interface TextBoxQuestionProps {
  questionId: number;
  question: string;
  answers: Record<string, string[]>;
  handleChange: (questionId: number, value: string | string[]) => void;
}

const TextBoxQuestion: React.FC<TextBoxQuestionProps> = ({
  questionId,
  question,
  answers,
  handleChange,
}) => {
  const storedAnswer = answers[questionId]?.[0] || "";

  return (
    <Question question={question}>
      <TextField
        value={storedAnswer}
        onChange={(e) => handleChange(questionId, e.target.value)}
        fullWidth
        margin="normal"
        variant="outlined"
        sx={{
          backgroundColor: "#f9f9f9",
          borderRadius: "8px",
          "& .MuiOutlinedInput-root": {
            borderRadius: "8px",
          },
        }}
      />
    </Question>
  );
};

export default TextBoxQuestion;
