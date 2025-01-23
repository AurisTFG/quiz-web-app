export interface QuizQuestionResponseDTO {
  id: number;
  question: string;
  questionType: "radio" | "checkbox" | "textbox";
  options: string[];
}

export interface QuizResultResponseDTO {
  email: string;
  score: number;
  submittedAt: Date;
}

export interface QuizSubmitResponseDTO {
  score: number;
}
