import React from "react";
import { FormControlLabel, Checkbox, FormLabel } from "@mui/material";

interface CheckboxQuestionProps {
  questionId: number;
  question: string;
  options: string[];
  answers: Record<string, string[]>;
  handleChange: (questionId: number, value: string | string[]) => void;
}

const CheckboxQuestion: React.FC<CheckboxQuestionProps> = ({
  questionId,
  question,
  options,
  answers,
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
      {options.map((option) => (
        <div key={option} style={{ textAlign: "left" }}>
          <FormControlLabel
            control={
              <Checkbox
                onChange={(e) => {
                  const value = e.target.checked
                    ? [...(answers[questionId] || []), option]
                    : (answers[questionId] || []).filter((ans) => ans !== option);
                  handleChange(questionId, value);
                }}
                sx={{
                  color: "#00796b",
                  "&.Mui-checked": {
                    color: "#00796b",
                  },
                }}
              />
            }
            label={option}
          />
        </div>
      ))}
    </div>
  );
};

export default CheckboxQuestion;
