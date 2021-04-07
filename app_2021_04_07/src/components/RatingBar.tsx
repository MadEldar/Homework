import React, { useState } from "react";
import '../css/RatingBar.css';

const RatingBox = ({index, state}: {index: number, state: any}) => {
    const [selectedRate, setSelectedRate] = state;

    function SelectRating() {
        setSelectedRate(index);
    }

    return (
        <button className={`button rating-box col mx-1 text-center text-white${selectedRate >= index ? ' highlighted' : ''}`} onClick={SelectRating}>
            <p className="my-2">{index}</p>
        </button>
    );
};

export const RatingBar = () => {
    const [selectedRate, setSelectedRate] = useState(0);

    const ratingArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    return (
        <div className="container mt-5">
            <div className="row col-8 offset-2">
                <div>
                    <h2>Rating bar</h2>
                </div>
                <div className="col-12">
                    <h3 className="text-center">{selectedRate}</h3>
                </div>
                {ratingArray.map(index => 
                    <RatingBox index={index} state={[selectedRate, setSelectedRate]} />
                )}
            </div>
        </div>
    )
}

export default RatingBar;