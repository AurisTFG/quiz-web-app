import React from "react";
import { FormControlLabel, Radio, RadioGroup } from "@mui/material";
import Question from "./Question";

interface RadioQuestionProps {
  questionId: number;
  question: string;
  options: string[];
  handleChange: (questionId: number, value: string | string[]) => void;
}

const RadioQuestion: React.FC<RadioQuestionProps> = ({
  questionId,
  question,
  options,
  handleChange,
}) => {
  return (
    <Question question={question}>
      <RadioGroup
        onChange={(e) => handleChange(questionId, e.target.value)}
        sx={{ display: "flex", flexDirection: "column" }}
      >
        {options.map((option) => (
          <FormControlLabel
            key={option}
            control={<Radio />}
            label={option}
            value={option}
            sx={{
              marginBottom: "10px",
              "& .MuiRadio-root": {
                color: "#00796b",
              },
            }}
          />
        ))}
      </RadioGroup>
    </Question>
  );
};

export default RadioQuestion;
