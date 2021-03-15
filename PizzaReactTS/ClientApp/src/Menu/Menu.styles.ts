import styled from 'styled-components';
import IconButton from '@material-ui/core/IconButton';

export const Wrapper = styled.div`
    margin: 0px;
    padding-top:8vh;
    padding-bottom:8vh;

`;
export const Sticky = styled.div`
position: -webkit-sticky; /* Safari */
position: sticky;
top: 6vh;
z-index:100;
`;

export const StyledButton = styled(IconButton)`
    z-index:100;
    float: right;
`;

export const TopContent = styled.div`
    height:50vh;
`;

export const Center = styled.div`
    text-align: center;
`;
