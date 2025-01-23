import React from "react";
import "./Spinner.css";

interface SpinnerProps {
  size?: number;
  color?: string;
}

const Spinner: React.FC<SpinnerProps> = ({ size = 80, color = "blue" }) => {
  return (
    <div
      className={`spinner`}
      style={{
        width: size,
        height: size,
        border: `${size * 0.1}px solid ${color}`,
        borderTop: `${size * 0.1}px solid transparent`,
      }}
    ></div>
  );
};

export default Spinner;
