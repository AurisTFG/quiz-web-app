import React from "react";
import { TextField, FormLabel } from "@mui/material";

interface TextBoxQuestionProps {
  questionId: number;
  question: string;
  handleChange: (questionId: number, value: string) => void;
}

const TextBoxQuestion: React.FC<TextBoxQuestionProps> = ({
  questionId,
  question,
  handleChange,
}) => {
  return (
    <div>
      <FormLabel
        sx={{
          fontSize: "1.1rem",
          fontWeight: 500,
          marginBottom: "10px",
          display: "block",
        }}
      >
        {question}
      </FormLabel>
      <TextField
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
    </div>
  );
};

export default TextBoxQuestion;
