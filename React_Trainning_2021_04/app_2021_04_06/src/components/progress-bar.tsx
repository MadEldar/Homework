import React from "react";

interface ProgressBarProps {
    backgroundColor: string;
    progressColor: string;
    width?: number;

}

export const ProgressBar = ({...props}: ProgressBarProps) => {
    return <div style={{...props}}>{`${props.width}%`}</div>
}

export default ProgressBar;