import styled from 'styled-components';

export const Wrapper = styled.div`
    display: flex;
    justify-content: space-between;
    flex-direction:column;
    width:100%;
    border: 1px solid black;
    border-radius: 1rem;
    height:100%;

    
    img {
        max-height: 250px;
        object-fit :cover;
        border-radius: 1rem 1rem 0 0;
        margin-bottom:-1.5em;
        z-index:1;
    }
    div {
        font-family: Arial, Helvetica, sans-serif;
        padding: 1rem;
        height:100%;
        background-color: #FAE6CA;
        overflow-wrap: break-word;
    }

    h3 {
        text-align:center;
        margin-bottom: -1em;
    }
    h4 {
        font-weight: 300;
        text-align: right;
        margin-bottom: -0.75em;
    }
    button {
        color:white;
        font-weight:700;
        background-color:#E31837;
        border-top: 1px solid black;
        border-radius: 0 0 1rem 1rem;
    }
`;