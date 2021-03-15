import styled from 'styled-components';

export const PendingBar = styled.div`
    height:24px;
    width:10%;
    background-color:red;
    float:left;
`;
export const InProgressBar = styled.div`
    height:24px;
    width:50%;
    background-color:orange;
    float:left;
`;
export const CompletedBar = styled.div`
    height:3rem;
    width:100%;
    background-color: green;
    margin:auto;
`;
export const BarText = styled.div` 
    margin:auto;
    width:30%
    border:3px solid ba
`;
export const BarBorder = styled.div`
height:3rem;
width:80%;
margin:auto;
display:inline-block;
border: 1px solid black;
margin-bottom:2rem;
font-family: Arial, sans-serif;
font-weight: 700;
color: #fff;
line-height:3rem;
`;