import styled from 'styled-components';
export const Wrapper = styled.div`
    display:flex;
    justify-content: space-between;
    font-family: Ariel, Helvetica, sans-serif;
    border-bottom: 1px solid black;
    padding-bottom: 20px;
    h3{
        margin: 0px;
    }

    div {
        flex:1;
    }
    .information, .buttons {
        display: flex;
        justify-content:space-between;
        margin-top:-0.5rem;
        margin-bottom:-0.5rem;
    }

    img{
        max-width: 80px;
        max-height: 80px;
        object-fit: cover;
        margin-left: 20px;
        margin-right: 20px;
        margin-top: 20px;
        border-radius:50%;
    }
`;