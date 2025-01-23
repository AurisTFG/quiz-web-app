import React from "react";
import { FormControlLabel, Checkbox } from "@mui/material";
import Question from "./Question";

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
    <Question question={question}>
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
    </Question>
  );
};

export default CheckboxQuestion;
