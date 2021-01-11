--
-- PostgreSQL database dump
--

-- Dumped from database version 10.13
-- Dumped by pg_dump version 10.13

-- Started on 2021-01-04 13:09:28

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
-- TOC entry 2849 (class 0 OID 16706)
-- Dependencies: 208
-- Data for Name: Countries; Type: TABLE DATA; Schema: public; Owner: dev
--

INSERT INTO public."Countries" VALUES (1, 'India', 'https://b.zmtcdn.com/images/countries/flags/country_1.png');
INSERT INTO public."Countries" VALUES (214, 'UAE', 'https://b.zmtcdn.com/images/countries/flags/country_214.png');
INSERT INTO public."Countries" VALUES (208, 'Turkey', 'https://b.zmtcdn.com/images/countries/flags/country_208.png');
INSERT INTO public."Countries" VALUES (191, 'Sri Lanka', 'https://b.zmtcdn.com/images/countries/flags/country_191.png');
INSERT INTO public."Countries" VALUES (189, 'South Africa', 'https://b.zmtcdn.com/images/countries/flags/country_189.png');
INSERT INTO public."Countries" VALUES (185, 'Slovakia', 'https://b.zmtcdn.com/images/countries/flags/country_185.png');
INSERT INTO public."Countries" VALUES (184, 'Singapore', 'https://b.zmtcdn.com/images/countries/flags/country_184.png');
INSERT INTO public."Countries" VALUES (166, 'Qatar', 'https://b.zmtcdn.com/images/countries/flags/country_166.png');
INSERT INTO public."Countries" VALUES (164, 'Portugal', 'https://b.zmtcdn.com/images/countries/flags/country_164.png');
INSERT INTO public."Countries" VALUES (163, 'Poland', 'https://b.zmtcdn.com/images/countries/flags/country_163.png');
INSERT INTO public."Countries" VALUES (162, 'Philippines', 'https://b.zmtcdn.com/images/countries/flags/country_162.png');
INSERT INTO public."Countries" VALUES (148, 'New Zealand', 'https://b.zmtcdn.com/images/countries/flags/country_148.png');
INSERT INTO public."Countries" VALUES (123, 'Malaysia', 'https://b.zmtcdn.com/images/countries/flags/country_123.png');
INSERT INTO public."Countries" VALUES (112, 'Lebanon', 'https://b.zmtcdn.com/images/countries/flags/country_112.png');
INSERT INTO public."Countries" VALUES (99, 'Italy', 'https://b.zmtcdn.com/images/countries/flags/country_99.png');
INSERT INTO public."Countries" VALUES (97, 'Ireland', 'https://b.zmtcdn.com/images/countries/flags/country_97.png');
INSERT INTO public."Countries" VALUES (94, 'Indonesia', 'https://b.zmtcdn.com/images/countries/flags/country_94.png');
INSERT INTO public."Countries" VALUES (54, 'Czech Republic', 'https://b.zmtcdn.com/images/countries/flags/country_54.png');
INSERT INTO public."Countries" VALUES (42, 'Chile', 'https://b.zmtcdn.com/images/countries/flags/country_42.png');
INSERT INTO public."Countries" VALUES (37, 'Canada', 'https://b.zmtcdn.com/images/countries/flags/country_37.png');
INSERT INTO public."Countries" VALUES (30, 'Brasil', 'https://b.zmtcdn.com/images/countries/flags/country_30.png');
INSERT INTO public."Countries" VALUES (14, 'Australia', 'https://b.zmtcdn.com/images/countries/flags/country_14.png');
INSERT INTO public."Countries" VALUES (215, 'United Kingdom', 'https://b.zmtcdn.com/images/countries/flags/country_215.png');
INSERT INTO public."Countries" VALUES (216, 'United States', 'https://b.zmtcdn.com/images/countries/flags/country_216.png');


--
-- TOC entry 2855 (class 0 OID 0)
-- Dependencies: 207
-- Name: Countries_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: dev
--

SELECT pg_catalog.setval('public."Countries_Id_seq"', 217, false);


-- Completed on 2021-01-04 13:09:28

--
-- PostgreSQL database dump complete
--

