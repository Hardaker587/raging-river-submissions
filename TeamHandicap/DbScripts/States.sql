--
-- PostgreSQL database dump
--

-- Dumped from database version 10.13
-- Dumped by pg_dump version 10.13

-- Started on 2021-01-04 13:25:41

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2851 (class 0 OID 16716)
-- Dependencies: 210
-- Data for Name: States; Type: TABLE DATA; Schema: public; Owner: dev
--

INSERT INTO public."States" VALUES (97, 'Nebraska', 'NE', 216);
INSERT INTO public."States" VALUES (96, 'North Dakota', 'ND', 216);
INSERT INTO public."States" VALUES (85, 'Kentucky', 'KY', 216);
INSERT INTO public."States" VALUES (118, 'Wyoming', 'WY', 216);
INSERT INTO public."States" VALUES (95, 'North Carolina', 'NC', 216);
INSERT INTO public."States" VALUES (94, 'Montana', 'MT', 216);
INSERT INTO public."States" VALUES (92, 'Missouri', 'MO', 216);
INSERT INTO public."States" VALUES (91, 'Minnesota', 'MN', 216);
INSERT INTO public."States" VALUES (90, 'Michigan', 'MI', 216);
INSERT INTO public."States" VALUES (89, 'Maine', 'ME', 216);
INSERT INTO public."States" VALUES (88, 'Maryland', 'MD', 216);
INSERT INTO public."States" VALUES (87, 'Massachusetts', 'MA', 216);
INSERT INTO public."States" VALUES (98, 'New Hampshire', 'NH', 216);
INSERT INTO public."States" VALUES (86, 'Louisiana', 'LA', 216);
INSERT INTO public."States" VALUES (93, 'Mississippi', 'MS', 216);
INSERT INTO public."States" VALUES (117, 'West Virginia', 'WV', 216);
INSERT INTO public."States" VALUES (103, 'New York State', 'NY', 216);
INSERT INTO public."States" VALUES (115, 'Washington State', 'WA', 216);
INSERT INTO public."States" VALUES (100, 'New Jersey', 'NJ', 216);
INSERT INTO public."States" VALUES (84, 'Kansas', 'KS', 216);
INSERT INTO public."States" VALUES (101, 'New Mexico', 'NM', 216);
INSERT INTO public."States" VALUES (102, 'Nevada', 'NV', 216);
INSERT INTO public."States" VALUES (104, 'Ohio', 'OH', 216);
INSERT INTO public."States" VALUES (105, 'Oklahoma', 'OK', 216);
INSERT INTO public."States" VALUES (106, 'Oregon', 'OR', 216);
INSERT INTO public."States" VALUES (107, 'Pennsylvania', 'PA', 216);
INSERT INTO public."States" VALUES (108, 'South Carolina', 'SC', 216);
INSERT INTO public."States" VALUES (109, 'South Dakota', 'SD', 216);
INSERT INTO public."States" VALUES (110, 'Tennessee', 'TN', 216);
INSERT INTO public."States" VALUES (111, 'Texas', 'TX', 216);
INSERT INTO public."States" VALUES (112, 'Utah', 'UT', 216);
INSERT INTO public."States" VALUES (113, 'Virginia', 'VA', 216);
INSERT INTO public."States" VALUES (114, 'Vermont', 'VT', 216);
INSERT INTO public."States" VALUES (116, 'Wisconsin', 'WI', 216);
INSERT INTO public."States" VALUES (83, 'Indiana', 'IN', 216);
INSERT INTO public."States" VALUES (128, 'New South Wales', 'NSW', 14);
INSERT INTO public."States" VALUES (81, 'Idaho', 'ID', 216);
INSERT INTO public."States" VALUES (127, 'The Territories', 'TT', 37);
INSERT INTO public."States" VALUES (126, 'Saskatchewan', 'SK', 37);
INSERT INTO public."States" VALUES (125, 'Quebec', 'QC', 37);
INSERT INTO public."States" VALUES (124, 'Ontario', 'ON', 37);
INSERT INTO public."States" VALUES (122, 'Manitoba', 'MB', 37);
INSERT INTO public."States" VALUES (121, 'British Columbia', 'BC', 37);
INSERT INTO public."States" VALUES (144, 'Nova Scotia', 'NS', 37);
INSERT INTO public."States" VALUES (119, 'Alberta', 'AB', 37);
INSERT INTO public."States" VALUES (140, 'Tasmania', 'TAS', 14);
INSERT INTO public."States" VALUES (133, 'Western Australia', 'WA', 14);
INSERT INTO public."States" VALUES (132, 'Victoria', 'VIC', 14);
INSERT INTO public."States" VALUES (131, 'South Australia', 'SA', 14);
INSERT INTO public."States" VALUES (130, 'Queensland', 'QLD', 14);
INSERT INTO public."States" VALUES (129, 'Northern Territory', 'NT', 14);
INSERT INTO public."States" VALUES (141, 'ACT', 'ACT', 14);
INSERT INTO public."States" VALUES (145, 'New Brunswick', 'NB', 37);
INSERT INTO public."States" VALUES (146, 'Prince Edward Island', 'PEI', 37);
INSERT INTO public."States" VALUES (147, 'Newfoundland and Labrador', 'NL', 37);
INSERT INTO public."States" VALUES (80, 'Iowa', 'IA', 216);
INSERT INTO public."States" VALUES (78, 'Georgia', 'GA', 216);
INSERT INTO public."States" VALUES (77, 'Florida', 'FL', 216);
INSERT INTO public."States" VALUES (76, 'Delaware', 'DE', 216);
INSERT INTO public."States" VALUES (75, 'Connecticut', 'CT', 216);
INSERT INTO public."States" VALUES (74, 'Colorado', 'CO', 216);
INSERT INTO public."States" VALUES (73, 'California', 'CA', 216);
INSERT INTO public."States" VALUES (72, 'Arizona', 'AZ', 216);
INSERT INTO public."States" VALUES (71, 'Arkansas', 'AR', 216);
INSERT INTO public."States" VALUES (70, 'Alabama', 'AL', 216);
INSERT INTO public."States" VALUES (69, 'Alaska', 'AK', 216);
INSERT INTO public."States" VALUES (143, 'Northern Ireland', 'Northern Ireland', 215);
INSERT INTO public."States" VALUES (142, 'England and Wales', 'England and Wales', 215);
INSERT INTO public."States" VALUES (134, 'Scotland', 'Sco', 215);
INSERT INTO public."States" VALUES (137, 'Rhode Island', 'RI', 216);
INSERT INTO public."States" VALUES (82, 'Illinois', 'IL', 216);
INSERT INTO public."States" VALUES (138, 'DC', 'DC', 216);


--
-- TOC entry 2857 (class 0 OID 0)
-- Dependencies: 209
-- Name: States_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: dev
--

SELECT pg_catalog.setval('public."States_Id_seq"', 148, false);


-- Completed on 2021-01-04 13:25:41

--
-- PostgreSQL database dump complete
--

