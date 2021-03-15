import styled from 'styled-components';
import TextField from '@material-ui/core/TextField';

export const Wrapper = styled.div`
    width: 60vw;
    padding:2rem;
`;

export const HalfInput =styled(TextField)`
    width: 50%;

`;

export const FullInput =styled(TextField)`
    width: 100%;

`;
export const Label = styled.label`
    font-size: small;
    font-family: Arial, sans-serif;
    color:grey;
`;