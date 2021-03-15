import styled from 'styled-components';
import TextField from '@material-ui/core/TextField'

export const Wrapper = styled.div`
    padding-top: 8vh;
    .flexbtn{
        height: 3.5rem;
    }
    .clear {
        float:right;
    }
    h1{
        font-family: Arial, sans-serif;
    }
`;
export const Center = styled.div`
    text-align: center;
`;
export const Input =styled(TextField)`
    padding-bottom: 2rem;
    height: 3.5rem;
    
`;
export const FlexC = styled.div`
    align-items:stretch
`;
export const Flex1 = styled.div`
    flex-grow:1;
`;
export const Flex2 = styled.div`
    flex-grow:2;
`;